/*
Rules: P09-top-level-one-unit
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Fixture: {"program":{"units":[{"source":"self"},{"source":"tests/P09-top-level-one-unit/iot-top-level-second.cs.part"}]}}
Mutate: System.Console.WriteLine(7);
Into: class Companion { }
*/
// top-level-statements.md L49: the other source still supplies one entry point.
System.Console.WriteLine(7);
