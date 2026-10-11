/*
Rules: E12-6-1-category-static-constructors
Authority: ECMA-334 7th ed 12.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Box() { Value = 31; }
Into: static Box() { Value = 17; }
*/
using System;
class Box { public static int Value; static Box() { Value = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Box.Value == 31, "static-constructor-statements");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
