/*
Rules: E15-3-9-3-class-nested-accessibilities
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: protected class Token
Into: private class Token
*/
using System;
class Packet { protected class Token { public int Read() { return 281; } } }
class Derived : Packet { public int Read() { return new Token().Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().Read() == 281, "protected-class-nested-type-accessible-in-derived");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
