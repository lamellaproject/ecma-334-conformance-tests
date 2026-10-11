/*
Rules: E15-5-4-volatile-enum-short
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile Mark Code;
Into: public volatile Mark Other;
*/
using System;
enum Mark : short { Ready = -21001 }
class Holder { public volatile Mark Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = Mark.Ready;
        Check((short)value.Code == -21001, "volatile-short-enum-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
