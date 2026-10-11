/*
Rules: E23-3-operator-decrement
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: p--;
Into: p++;
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
            int* first = stackalloc int[2];
            int* p = first + 1;
            p--;
            Check(p == first, "decrement-pointer");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
