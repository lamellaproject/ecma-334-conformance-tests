/*
Rules: E10-5-4-target-exact
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long result=input;
Into: long result=default(long);
*/
using System;


static class Trace {public static string Log="";}
struct Packet {public int Number;
    public static implicit operator int(Packet x){Trace.Log+="int";return x.Number;}
    public static implicit operator long(Packet x){Trace.Log+="long";return x.Number+1;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet input=new Packet {Number=61}; long result=input;
        Check(result==62 && Trace.Log=="long", "E10-5-4-target-exact-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
