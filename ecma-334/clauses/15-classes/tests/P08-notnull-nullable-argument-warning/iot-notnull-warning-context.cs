/*
Rules: P08-notnull-nullable-argument-warning
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 0
Diagnostic: none
Mutate: #nullable disable warnings
Into: #nullable enable warnings
*/
#nullable enable
using System;
class Box<T> where T : notnull { }
class Program
{
    static int Main()
    {
#nullable disable warnings
        Box<int?> value = new Box<int?>();
        if (value == null) return 1;
        Console.WriteLine("OK 0");
        return 0;
    }
}
