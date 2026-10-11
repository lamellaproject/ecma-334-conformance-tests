/*
Rules: E12-9-1-form-indirection; E12-9-1-form-address
Authority: ECMA-334 7th ed 12.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* pointer = &value
Into: int* pointer = null
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 7; int* pointer = &value;
        Check(pointer != null, "address-produces-pointer");
        if (pointer != null) { *pointer = 12; Check(value == 12, "indirection-designates-original"); }
        else { Check(false, "indirection-designates-original"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
