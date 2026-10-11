/*
Rules: E7-3-type-constructor-overloads; E7-6-constructor-overloading; E7-6-constructor-signature
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Holder(string argument)
Into: Holder(int argument)
*/
using System;
class Holder
{
    public int Value;
    public Holder(int argument) { Value = 17; }
    public Holder(string argument) { Value = 23; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder(1).Value == 17, "integer-constructor-signature");
        Check(new Holder("leaf").Value == 23, "string-constructor-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
