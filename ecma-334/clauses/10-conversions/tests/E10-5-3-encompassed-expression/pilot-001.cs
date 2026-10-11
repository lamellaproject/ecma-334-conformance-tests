/*
Rules: E10-5-3-encompassed-expression; E10-5-4-source-type; E10-4-2-categories
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet converted=61;
Into: Packet converted=default(Packet);
*/
using System;


struct Packet {public int Number; public static int Calls; public static implicit operator Packet(byte x){Calls++;return new Packet {Number=x};}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet converted=61;
        Check(converted.Number==61 && Packet.Calls==1, "E10-5-3-encompassed-expression-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
