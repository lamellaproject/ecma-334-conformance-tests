/*
Rules: E15-5-4-volatile-int; E15-5-4-volatile-classification
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile int Code;
Into: public volatile int Other;
*/
using System;
class Holder { public volatile int Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = -7654321;
        Check(value.Code == -7654321, "volatile-int-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
