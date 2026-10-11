/*
Rules: E23-3-method-pointer-return
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return p;
Into: return null;
*/
using System;
class Item { public static unsafe int* Identity(int* p) { return p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 97;
            Check(Item.Identity(&value) == &value, "pointer-method-return");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
