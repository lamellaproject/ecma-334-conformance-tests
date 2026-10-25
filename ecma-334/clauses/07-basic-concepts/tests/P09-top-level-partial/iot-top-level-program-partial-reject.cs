/*
Rules: P09-top-level-partial
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: class Program
Into: partial class Program
*/
using System;

// top-level-statements.md L84: the generated partial type combines declarations.
Console.WriteLine(Program.Marker);
class Program { public static int Marker = 31; }
