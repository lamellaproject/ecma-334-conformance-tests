/*
Rules: E15-3-9-3-class-nested-accessibilities
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Token
Into: private class Token
*/
using System;
class Packet { public class Token { public int Read() { return 269; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Packet.Token().Read() == 269, "public-class-nested-type-accessible-outside");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
