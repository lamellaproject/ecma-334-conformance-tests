/*
Rules: E10-2-13-order; E10-3-6-order
Authority: ECMA-334 7th ed 10.2.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (long a,long b) converted=(Trace.Make(1),Trace.Make(2));
Into: (long a,long b) converted=(0L,0L);
*/
using System;


static class Trace {public static string Log="";public static Packet Make(int n){Log+="make"+n+";";return new Packet {Number=n};}}
struct Packet {public int Number;
    public static implicit operator long(Packet p){Trace.Log+="convert"+p.Number+";";return p.Number;}
    public static explicit operator byte(Packet p){Trace.Log+="convert"+p.Number+";";return (byte)p.Number;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Trace.Log=""; (long a,long b) converted=(Trace.Make(1),Trace.Make(2));
        Check(converted.a==1 && converted.b==2 && Trace.Log=="make1;convert1;make2;convert2;", "E10-2-13-order-pilot-001-check-01");
        Trace.Log=""; (byte a,byte b) narrowed=((byte,byte))(Trace.Make(3),Trace.Make(4));
        Check(narrowed.a==3 && narrowed.b==4 && Trace.Log=="make3;convert3;make4;convert4;", "E10-2-13-order-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
