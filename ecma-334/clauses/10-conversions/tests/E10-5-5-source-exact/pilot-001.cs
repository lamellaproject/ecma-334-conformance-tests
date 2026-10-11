/*
Rules: E10-5-5-source-exact; E10-5-5-operator
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet result=(Packet)input;
Into: Packet result=default(Packet);
*/
using System;


static class Trace {public static string Log="";}
struct Packet {public int Number;
    public static explicit operator Packet(int x){Trace.Log+="int";return new Packet {Number=x};}
    public static explicit operator Packet(long x){Trace.Log+="long";return new Packet {Number=-1};}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input=61; Packet result=(Packet)input;
        Check(result.Number==61 && Trace.Log=="int", "E10-5-5-source-exact-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
