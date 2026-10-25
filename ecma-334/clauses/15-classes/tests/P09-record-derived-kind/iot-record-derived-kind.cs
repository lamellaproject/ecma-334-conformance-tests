/*
Rules: P09-record-derived-kind
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: class Descendant : Ancestor { }
Into: record Descendant : Ancestor { }
Csc: CS8865
*/
record Ancestor { }
class Descendant : Ancestor { }
class Program { static void Main() { } }
