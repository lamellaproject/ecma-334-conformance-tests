/*
Rules: E14-7-grammar-type-declaration-5; E14-7-type-in-class
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: delegate int Transform
Into: delegate string Transform
*/
using System;
class Owner { public delegate int Transform(int value); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next(int value) { return value + 1; }
    static void Main()
    {
        Owner.Transform action = Next;
        Check(action(28) == 29, "class-nested-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
