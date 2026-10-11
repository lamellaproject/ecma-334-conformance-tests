/*
Rules: E15-5-4-volatile-enum-sbyte
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile Mark Code;
Into: public volatile Mark Other;
*/
using System;
enum Mark : sbyte { Ready = -79 }
class Holder { public volatile Mark Code; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        value.Code = Mark.Ready;
        Check((sbyte)value.Code == -79, "volatile-sbyte-enum-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
