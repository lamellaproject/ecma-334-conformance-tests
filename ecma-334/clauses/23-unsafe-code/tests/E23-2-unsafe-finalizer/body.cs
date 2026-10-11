/*
Rules: E23-2-unsafe-finalizer; E23-2-finalizer-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: unsafe ~Item()
Into: ~Item()
*/
using System;
class Item { public static int Value; unsafe ~Item() { int value = 23; int* p = &value; Value = *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
