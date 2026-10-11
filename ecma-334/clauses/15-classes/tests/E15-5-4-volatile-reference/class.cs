/*
Rules: E15-5-4-volatile-reference
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public volatile Packet Value;
Into: public volatile Packet Other;
*/
using System;
class Packet { }
class Holder { public volatile Packet Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Packet input = new Packet();
        value.Value = input;
        Check(value.Value == input, "volatile-class-reference-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
