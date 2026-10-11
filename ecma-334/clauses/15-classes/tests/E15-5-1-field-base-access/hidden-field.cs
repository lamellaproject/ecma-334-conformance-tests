/*
Rules: E15-5-1-field-base-access
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return base.Code;
Into: return Code;
*/
using System;
class Basis { public int Code = 263; }
class Holder : Basis
{
    public new int Code = 277;
    public int ReadBase() { return base.Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.ReadBase() == 263, "base-access-bypasses-hidden-field");
        Check(value.Code == 277, "derived-field-distinct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
