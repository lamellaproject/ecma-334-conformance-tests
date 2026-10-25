/*
Rules: P09-record-base-kind
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: class Ancestor { }
Into: record Ancestor { }
Csc: CS8864
*/
class Ancestor { }
record Descendant : Ancestor { }
class Program { static void Main() { } }
