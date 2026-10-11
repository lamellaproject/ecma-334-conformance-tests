/*
Rules: E6-4-4-grammar-keyword-20
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: enum Heading
Into: class Heading
*/
using System;
enum Heading { North = 5, South = 8 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Heading item = Heading.South;
        Check((int)item == 8, "enum-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
