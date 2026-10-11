/*
Rules: E15-3-9-3-struct-nested-internal-accessibility
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal class Token
Into: private class Token
*/
using System;
struct Packet { internal class Token { public int Read() { return 313; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Packet.Token().Read() == 313, "internal-struct-nested-type-accessible-in-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
