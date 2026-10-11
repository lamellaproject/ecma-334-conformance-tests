/*
Rules: E23-7-array-initializer; E23-7-form-expression-initializer; E23-7-array-initializer-result; E23-7-array-initializer-pins
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: fixed (int* pointer = items)
Into: fixed (int* pointer = other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] items = { 31, 47 }, other = { 5, 11 };
        fixed (int* pointer = items)
        {
            Check(*pointer == items[0], "array-first-element-address");
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            fixed (int* after = &items[0]) Check(pointer == after, "array-address-after-collection");
            Check(pointer[0] == 31 && pointer[1] == 47, "whole-array-pin-values");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
