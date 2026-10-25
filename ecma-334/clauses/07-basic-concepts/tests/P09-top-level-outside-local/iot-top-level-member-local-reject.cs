/*
Rules: P09-top-level-outside-local
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: return local;
Into: return 17;
*/
using System;

// top-level-statements.md L198/199: member access cannot capture the entry local.
int local = 17;
Console.WriteLine(local);
Console.WriteLine(new Worker().Read());
class Worker { public int Read() { return local; } }
