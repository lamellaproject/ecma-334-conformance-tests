/*
Rules: E15-3-9-3-class-nested-accessibilities
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private protected class Token
Into: private class Token
*/
using System;
class Packet { private protected class Token { public int Read() { return 293; } } }
class Derived : Packet { public int Read() { return new Token().Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().Read() == 293, "private-protected-nested-type-accessible-in-derived-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
