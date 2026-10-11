"""Measure source-keyed applicability bounds and an independent all-level sample."""
import sys

from suite_common import main_guard
from suite_measurements import Measurement, ObservationRegistry, interval, predecessor, witness_for
from suite_version_schedule import main


if __name__ == "__main__":
    sys.exit(main_guard(main))
