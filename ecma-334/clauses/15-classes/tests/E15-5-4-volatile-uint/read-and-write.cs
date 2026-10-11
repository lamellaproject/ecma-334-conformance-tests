/*
Rules: E15-5-4-volatile-uint
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile uint Code;
Into: public volatile uint Other;
*/
using System;
class Holder { public volatile uint Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = 0xf5432101u;
        Check(value.Code == 0xf5432101u, "volatile-uint-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
