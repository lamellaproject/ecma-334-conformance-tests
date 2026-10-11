/*
Rules: E15-3-1-field-category; E15-3-1-grammar-class-member-declaration-form-2
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Number;
Into: public readonly int Number;
*/
using System;
class Cell { public int Number; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell first = new Cell(), second = new Cell();
        first.Number = 89;
        second.Number = 97;
        Check(first.Number == 89, "first-class-variable");
        Check(second.Number == 97, "second-class-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
