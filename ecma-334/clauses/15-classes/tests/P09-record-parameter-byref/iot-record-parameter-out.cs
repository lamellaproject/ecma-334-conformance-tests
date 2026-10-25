/*
Rules: P09-record-parameter-byref
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: record Sluice(out int Position);
Into: record Sluice(int Position);
Csc: CS0631
*/
record Sluice(out int Position);
class Program { static void Main() { } }
