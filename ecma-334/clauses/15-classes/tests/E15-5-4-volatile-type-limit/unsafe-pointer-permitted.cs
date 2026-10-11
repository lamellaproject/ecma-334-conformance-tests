/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile int* Address;
Into: public volatile int* Other;
*/
using System;
// The pointer permission in 23.3 supplements the type list in 15.5.4.
unsafe class Holder { public volatile int* Address; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    unsafe static void Main()
    {
        int local = 257;
        Holder value = new Holder();
        value.Address = &local;
        Check(*value.Address == 257, "volatile-pointer-explicit-unsafe-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
