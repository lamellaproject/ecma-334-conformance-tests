/*
Rules: E15-3-8-static-no-receiver; E15-3-8-static-modifier-classifies
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static int Value
Into: public int Value
*/
using System;
class Register { public static int Value { get { return 149; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Register.Value == 149, "static-property-without-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
