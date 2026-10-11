/*
Rules: E10-1-custom; E10-5-1-class-struct; E10-2-14-chain; E10-4-1-standard; E10-4-2-categories; E10-5-2-underlying; E10-5-3-lookup-types; E10-5-3-applicable; E10-5-3-pre; E10-5-3-invoke; E10-5-3-post; E10-5-4-source-type; E10-5-4-applicable; E10-5-4-pre; E10-5-4-invoke; E10-5-4-post; E10-5-4-type-from-variable; E10-2-1-categories
Authority: ECMA-334 7th ed 10.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Packet converted=input;
Into: Packet converted=new Packet();
*/
using System;


static class Trace {public static string Log="";}
struct Packet {
    public int Number;
    public static implicit operator Packet(int x) {Trace.Log+="in:"+x+";"; return new Packet {Number=x};}
    public static implicit operator int(Packet x) {Trace.Log+="out:"+x.Number+";"; return x.Number+1;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        short input=61; Packet converted=input; long? result=converted;
        Check(converted.Number==61 && result.HasValue && result.Value==62 && Trace.Log=="in:61;out:61;", "E10-1-custom-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
