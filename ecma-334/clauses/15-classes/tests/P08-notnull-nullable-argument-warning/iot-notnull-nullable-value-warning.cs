/*
Rules: P08-notnull-nullable-argument-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: Box<int?> value = new Box<int?>();
Into: Box<int> value = new Box<int>();
*/
#nullable enable
using System;
class Box<T> where T : notnull { }
class Program
{
    static int Main()
    {
        Box<int?> value = new Box<int?>();
        if (value == null) return 1;
        Console.WriteLine("OK 0");
        return 0;
    }
}
