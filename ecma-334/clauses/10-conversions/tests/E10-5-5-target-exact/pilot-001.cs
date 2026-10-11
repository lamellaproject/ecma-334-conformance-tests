/*
Rules: E10-5-5-target-exact
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: long result=(long)source;
Into: long result=default(long);
*/
using System;


static class Trace {public static string Log="";}
struct Packet {
    public static explicit operator int(Packet x){Trace.Log+="int";return 61;}
    public static explicit operator long(Packet x){Trace.Log+="long";return 62;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet source=new Packet(); long result=(long)source;
        Check(result==62 && Trace.Log=="long", "E10-5-5-target-exact-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
