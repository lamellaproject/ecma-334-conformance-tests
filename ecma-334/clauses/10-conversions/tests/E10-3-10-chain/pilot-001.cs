/*
Rules: E10-3-10-chain; E10-4-3-implicit; E10-4-3-opposite; E10-5-5-source-type; E10-5-5-applicable; E10-5-5-pre; E10-5-5-invoke; E10-5-5-post; E10-5-5-type-from-variable; E10-3-1-categories
Authority: ECMA-334 7th ed 10.3.10
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Packet packet=(Packet)input;
Into: Packet packet=default(Packet);
*/
using System;


class Parent {public int Number;} class Child:Parent {}
static class Trace {public static string Log="";}
struct Packet {public int Number;
    public static explicit operator Packet(Child x){Trace.Log+="in:"+x.Number+";";return new Packet {Number=x.Number};}
    public static explicit operator Parent(Packet x){Trace.Log+="out:"+x.Number+";";return new Child {Number=x.Number+1};}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent input=new Child {Number=61}; Packet packet=(Packet)input; Child child=(Child)packet;
        Check(packet.Number==61 && child.Number==62 && Trace.Log=="in:61;out:61;", "E10-3-10-chain-pilot-001-check-01");
        Trace.Log="";
        try { Packet fail=(Packet)new Parent(); Check(false, "E10-3-10-chain-pilot-001-check-02"); } catch(InvalidCastException) { Check(Trace.Log=="", "E10-3-10-chain-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-3-10-chain-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
