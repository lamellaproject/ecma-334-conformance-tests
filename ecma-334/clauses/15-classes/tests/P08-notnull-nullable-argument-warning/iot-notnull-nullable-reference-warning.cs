/*
Rules: P08-notnull-nullable-argument-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: Box<string?> value = new Box<string?>();
Into: Box<string> value = new Box<string>();
*/
#nullable enable
using System;
class Box<T> where T : notnull { }
class Program
{
    static int Main()
    {
        Box<string?> value = new Box<string?>();
        if (value == null) return 1;
        Console.WriteLine("OK 0");
        return 0;
    }
}
