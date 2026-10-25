/*
Rules: P09-record-constructor-delegation
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public Valve() { }
Into: public Valve() : this(4) { }
Csc: CS8862
*/
record Valve(int Position) { public Valve() { } }
class Program { static void Main() { } }
