/*
Rules: E15-3-9-3-class-nested-accessibilities
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private class Token
Into: private class Other
*/
using System;
class Packet
{
    private class Token { public int Read() { return 277; } }
    public int Read() { return new Token().Read(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Packet().Read() == 277, "private-class-nested-type-accessible-in-container");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
