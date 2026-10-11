/*
Rules: E8-2-1-nonarray-form-pointer
Authority: ECMA-334 7th ed 8.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe class PointerArray
Into: class PointerArray
*/
using System;
unsafe class PointerArray { public static int Length() { int*[] slots = new int*[2]; return slots.Length; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(PointerArray.Length() == 2, "pointer-array-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
