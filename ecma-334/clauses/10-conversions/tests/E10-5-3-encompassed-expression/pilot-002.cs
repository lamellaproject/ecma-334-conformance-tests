/*
Rules: E10-5-3-encompassed-expression; E10-4-2-categories
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet converted=null;
Into: Packet converted=default(Packet);
*/
using System;

struct Packet {public int Number; public static implicit operator Packet(string x){return new Packet {Number=x==null?61:0};}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet converted=null;
        Check(converted.Number==61, "E10-5-3-encompassed-expression-pilot-002-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
