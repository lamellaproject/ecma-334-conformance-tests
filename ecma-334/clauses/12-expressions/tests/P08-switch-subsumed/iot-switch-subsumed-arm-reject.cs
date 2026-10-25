/*
Rules: P08-switch-subsumed
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: _ => 11, 3 => 19
Into: 3 => 19, _ => 11
*/
using System;

// patterns.md L299; committee switch expressions prohibit subsumed arms.
class Program
{
    static void Main(string[] args)
    {
        int result = args.Length switch { _ => 11, 3 => 19 };
        Console.WriteLine(result);
    }
}
