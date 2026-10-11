/*
Rules: E15-3-9-7-implicitly-generic-nested
Authority: ECMA-334 7th ed 15.3.9.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: typeof(Box<string>.Cell)
Into: typeof(Box<int>.Cell)
*/
using System;
class Box<T> { public class Cell { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(typeof(Box<int>.Cell) != typeof(Box<string>.Cell), "nested-class-identity-includes-outer-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
