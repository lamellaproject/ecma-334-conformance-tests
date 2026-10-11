"""Discover the Framework targeting pack and record its serviced Windows runtime."""
from __future__ import annotations

import ctypes
import os
import sys
from pathlib import Path

from suite_common import canonical, sha


def reference_roots(variables):
    for name in variables:
        if os.environ.get(name):
            yield canonical(os.environ[name])
    program_files = os.environ.get("ProgramFiles(x86)")
    if program_files:
        yield canonical(Path(program_files) / "Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8")


def file_version(path):
    """Read the numeric Windows file version without launching another process."""
    from ctypes import wintypes
    library = ctypes.WinDLL("version", use_last_error=True)
    size_of = library.GetFileVersionInfoSizeW
    size_of.argtypes, size_of.restype = [wintypes.LPCWSTR, ctypes.POINTER(wintypes.DWORD)], wintypes.DWORD
    get_info = library.GetFileVersionInfoW
    get_info.argtypes, get_info.restype = [wintypes.LPCWSTR, wintypes.DWORD, wintypes.DWORD, ctypes.c_void_p], wintypes.BOOL
    query = library.VerQueryValueW
    query.argtypes, query.restype = [ctypes.c_void_p, wintypes.LPCWSTR, ctypes.POINTER(ctypes.c_void_p), ctypes.POINTER(wintypes.UINT)], wintypes.BOOL
    unused = wintypes.DWORD()
    size = size_of(str(path), ctypes.byref(unused))
    if not size:
        raise ValueError("Framework runtime file has no version: " + str(path))
    data = ctypes.create_string_buffer(size)
    pointer, length = ctypes.c_void_p(), wintypes.UINT()
    if not get_info(str(path), 0, size, data) or not query(data, "\\", ctypes.byref(pointer), ctypes.byref(length)) or length.value < 52:
        raise ValueError("Cannot read Framework runtime file version: " + str(path))
    words = ctypes.cast(pointer, ctypes.POINTER(wintypes.DWORD))
    if words[0] != 0xFEEF04BD:
        raise ValueError("Invalid Framework runtime file version")
    return ".".join(str(value) for value in (words[2] >> 16, words[2] & 65535, words[3] >> 16, words[3] & 65535))


def installed_runtime():
    if sys.platform != "win32":
        raise ValueError("The Framework runtime requires Windows")
    import winreg
    try:
        with winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, r"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full",
                            0, winreg.KEY_READ | winreg.KEY_WOW64_64KEY) as key:
            release = winreg.QueryValueEx(key, "Release")[0]
            version = winreg.QueryValueEx(key, "Version")[0]
            path = winreg.QueryValueEx(key, "InstallPath")[0]
    except OSError as error:
        raise ValueError("The .NET Framework Full runtime is not installed") from error
    return {"release": release, "version": version, "directory": canonical(path)}


def runtime_identity(minimum_release):
    installed = installed_runtime()
    if type(installed["release"]) is not int or installed["release"] < minimum_release:
        raise ValueError("This target requires .NET Framework 4.8.1 or later")
    directory = installed["directory"]
    if directory.parent.name.lower() != "framework64":
        raise ValueError("This target requires the x64 Framework runtime")
    assets = {}
    for name in ("mscorlib.dll", "clr.dll", "clrjit.dll"):
        path = directory / name
        if not path.is_file():
            raise ValueError("Framework runtime asset is missing: " + name)
        assets[name] = {"path": str(path), "sha256": sha(path), "version": file_version(path)}
    return {"kind": "netframework", "architecture": "x64", "release": installed["release"],
            "version": installed["version"], "assets": assets}
