/*
Rules: E23-2-unsafe-method; E23-2-method-context; E23-2-modifier-effect-member
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static unsafe int Read
Into: static int Read
*/
using System;
class Item { public static unsafe int Read(int* p) { return *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 11;
            Check(Item.Read(&value) == 11, "unsafe-method-signature-and-body");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
