/*
Rules: E7-3-type-constructor-overloads; E7-6-constructor-overloading
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Holder(string argument)
Into: Holder(int argument)
*/
using System;
struct Holder
{
    public int Value;
    public Holder(int argument) { Value = 29; }
    public Holder(string argument) { Value = 31; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder(1).Value == 29, "struct-integer-constructor");
        Check(new Holder("leaf").Value == 31, "struct-string-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
