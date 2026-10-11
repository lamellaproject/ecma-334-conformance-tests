/*
Rules: E23-6-5-form-address-of; E23-6-5-address-result; E23-6-5-address-type
Authority: ECMA-334 7th ed 23.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: short* address = &value;
Into: short* address = &other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        short value = 61, other = 5;
        short* address = &value;
        Check(*address == 61, "typed-address-referent");
        *address = 71;
        Check(value == 71 && other == 5, "typed-address-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
