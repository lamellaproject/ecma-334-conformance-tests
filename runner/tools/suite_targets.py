"""Batch runtime adapters; an adapter returns exactly one observation per artifact."""
from __future__ import annotations

import json
import time
import uuid
from concurrent.futures import ThreadPoolExecutor
from pathlib import Path

from suite_common import checked_object, sha, write_json
from suite_config import expand


class Target:
    def __init__(self, config, assets, output, execute):
        self.config, self.assets, self.output, self.execute = config, assets, output, execute

    def prepare(self, entry):
        build = self.config["build"]
        if build["runtimeconfig"]:
            path = entry.with_suffix(".runtimeconfig.json")
            write_json(path, {"runtimeOptions": {"tfm": build["tfm"], "framework": {
                "name": build["framework"], "version": build["runtime_version"]}, "rollForward": "Disable"}})
            return path
        return None

    def command(self, request):
        return expand(self.config["command"], {**self.assets, "entry": request["entry"]}, {"arguments": request["arguments"]})

    def dotnet_one(self, request):
        command = self.command(request)
        code, stdout, stderr, elapsed = self.execute(command, request["timeout_seconds"], Path(request["entry"]).parent)
        return {"id": request["id"], "exit": code, "stdout": stdout, "stderr": stderr,
                "elapsed_seconds": elapsed, "command": command}

    def run_batch(self, requests, jobs):
        if not requests:
            return []
        if len({r["id"] for r in requests}) != len(requests):
            raise ValueError("Duplicate batch artifact identity")
        for request in requests:
            if not request["artifacts"] or any(sha(p) != expected for p, expected in request["artifacts"].items()):
                raise ValueError("Runtime artifact changed before batch execution")
        rows = []
        for offset in range(0, len(requests), self.config["batch_size"]):
            batch = requests[offset:offset + self.config["batch_size"]]
            if self.config["adapter"] in {"dotnet", "netframework"}:
                with ThreadPoolExecutor(max_workers=jobs) as pool:
                    rows.extend(pool.map(self.dotnet_one, batch))
                continue
            directory = self.output / "batches" / uuid.uuid4().hex
            directory.mkdir(parents=True, exist_ok=True)
            request_path, response_path = directory / "request.json", directory / "response.json"
            write_json(request_path, {"schema_version": 1, "programs": batch})
            command = expand(self.config["command"], {**self.assets, "request": str(request_path), "response": str(response_path)})
            budget = sum(r["timeout_seconds"] for r in batch) + 30
            code, stdout, stderr, elapsed = self.execute(command, budget, directory)
            write_json(directory / "adapter.json", {"command": command, "exit": code, "stdout": stdout, "stderr": stderr, "elapsed_seconds": elapsed})
            if code != 0 or not response_path.is_file():
                rows.extend({"id": r["id"], "exit": "launch-error", "stdout": "", "stderr": "Batch adapter failed: " + stderr,
                             "elapsed_seconds": elapsed, "command": command} for r in batch)
                continue
            response = json.loads(response_path.read_text(encoding="utf-8"))
            checked_object(response, {"schema_version", "programs"}, {"schema_version", "programs"})
            if response["schema_version"] != 1 or not isinstance(response["programs"], list):
                raise ValueError("Invalid batch response schema")
            returned = response["programs"]
            if len(returned) != len(batch) or {r.get("id") for r in returned} != {r["id"] for r in batch}:
                raise ValueError("Batch response must return every artifact exactly once")
            for row in returned:
                checked_object(row, {"id", "exit", "stdout", "stderr", "elapsed_seconds"}, {"id", "exit", "stdout", "stderr", "elapsed_seconds"})
                if not (type(row["exit"]) is int or row["exit"] in {"timeout", "launch-error"}):
                    raise ValueError("Invalid batch exit observation")
                if any(not isinstance(row[k], str) for k in ("id", "stdout", "stderr")):
                    raise ValueError("Batch streams must be strings")
                if type(row["elapsed_seconds"]) not in {int, float} or row["elapsed_seconds"] < 0:
                    raise ValueError("Invalid batch elapsed time")
                rows.append(dict(row, command=command))
        return rows
