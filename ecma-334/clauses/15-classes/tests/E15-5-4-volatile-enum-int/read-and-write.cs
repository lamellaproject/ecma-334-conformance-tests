/*
Rules: E15-5-4-volatile-enum-int
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile Mark Code;
Into: public volatile Mark Other;
*/
using System;
enum Mark : int { Ready = -17000001 }
class Holder { public volatile Mark Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = Mark.Ready;
        Check((int)value.Code == -17000001, "volatile-int-enum-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
