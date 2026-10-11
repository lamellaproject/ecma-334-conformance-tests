/*
Rules: E15-3-9-3-class-nested-default-private
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Token { public int Read() { return 307; } }
Into: class Other { public int Read() { return 307; } }
*/
using System;
class Packet
{
    class Token { public int Read() { return 307; } }
    public int Read() { return new Token().Read(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Packet().Read() == 307, "default-class-nested-type-accessible-in-container");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
