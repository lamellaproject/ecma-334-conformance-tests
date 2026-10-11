/*
Rules: E23-3-operator-fixed
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: fixed (int* p = first)
Into: fixed (int* p = second)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int[] first = { 7 };
            int[] second = { 11 };
            fixed (int* p = first) { *p = 13; }
            Check(first[0] == 13, "fixed-array-address");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
