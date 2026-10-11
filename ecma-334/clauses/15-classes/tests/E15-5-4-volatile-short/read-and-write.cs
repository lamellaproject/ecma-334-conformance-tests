/*
Rules: E15-5-4-volatile-short
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile short Code;
Into: public volatile short Other;
*/
using System;
class Holder { public volatile short Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = -19001;
        Check(value.Code == -19001, "volatile-short-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
