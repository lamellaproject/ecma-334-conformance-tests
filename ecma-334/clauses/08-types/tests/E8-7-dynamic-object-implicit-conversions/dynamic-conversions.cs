/*
Rules: E8-7-dynamic-object-implicit-conversions; E8-7-dynamic-object-explicit-conversions
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic value = 64;
Into: dynamic value = 65;
*/
using System;
class Receiver { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic value = 64; object boxed = value; dynamic again = boxed; int unboxed = (int)again;
        Receiver receiver = new Receiver(); dynamic reference = receiver; object objectView = reference;
        Check(unboxed == 64 && objectView == receiver, "dynamic-object-boxing-reference-and-unboxing");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
