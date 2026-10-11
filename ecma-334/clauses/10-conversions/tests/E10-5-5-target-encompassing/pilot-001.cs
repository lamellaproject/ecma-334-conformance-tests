/*
Rules: E10-5-5-target-encompassing
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: byte result=(byte)source;
Into: byte result=default(byte);
*/
using System;


static class Trace {public static string Log="";}
struct Packet {
    public static explicit operator short(Packet x){Trace.Log+="short";return 61;}
    public static explicit operator int(Packet x){Trace.Log+="int";return 62;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet source=new Packet(); byte result=(byte)source;
        Check(result==61 && Trace.Log=="short", "E10-5-5-target-encompassing-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
