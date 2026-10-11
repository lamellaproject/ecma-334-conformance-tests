/*
Rules: E15-5-4-volatile-bool
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile bool Ready;
Into: public volatile bool Other;
*/
using System;
class Holder { public volatile bool Ready; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Ready = true;
        Check(value.Ready, "volatile-bool-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
