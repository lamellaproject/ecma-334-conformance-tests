/*
Rules: E15-5-4-volatile-sbyte
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile sbyte Code;
Into: public volatile sbyte Other;
*/
using System;
class Holder { public volatile sbyte Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = -83;
        Check(value.Code == -83, "volatile-sbyte-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
