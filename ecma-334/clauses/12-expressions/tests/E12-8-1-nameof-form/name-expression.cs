/*
Rules: E12-8-1-nameof-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(Cell)
Into: nameof(Other)
*/
using System;
class Cell { }
class Other { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = nameof(Cell);
        Check(result == "Cell", "nameof-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
