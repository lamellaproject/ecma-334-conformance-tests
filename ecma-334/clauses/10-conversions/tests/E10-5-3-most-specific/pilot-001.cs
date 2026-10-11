/*
Rules: E10-5-3-most-specific; E10-5-3-encompassed-type; E10-5-4-source-exact; E10-5-4-operator
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet result=input;
Into: Packet result=new Packet();
*/
using System;


static class Trace {public static string Log="";}
struct Packet {public int Number;
    public static implicit operator Packet(int x){Trace.Log+="int";return new Packet {Number=x};}
    public static implicit operator Packet(long x){Trace.Log+="long";return new Packet {Number=-1};}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input=61; Packet result=input;
        Check(result.Number==61 && Trace.Log=="int", "E10-5-3-most-specific-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
