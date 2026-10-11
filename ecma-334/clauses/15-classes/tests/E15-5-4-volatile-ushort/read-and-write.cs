/*
Rules: E15-5-4-volatile-ushort
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile ushort Code;
Into: public volatile ushort Other;
*/
using System;
class Holder { public volatile ushort Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = 59001;
        Check(value.Code == 59001, "volatile-ushort-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
