/*
Rules: E15-11-3-field-initializer-textual-order
Authority: ECMA-334 7th ed 15.11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int First = Program.Init("F", 13); public int Second = Program.Init("S", 19);
Into: public int Second = Program.Init("S", 19); public int First = Program.Init("F", 13);
*/
using System;
class Basis { public Basis() { Program.Trace += "B"; } }
class Gauge : Basis
{
    public int First = Program.Init("F", 13); public int Second = Program.Init("S", 19);
    public Gauge() : base() { Program.Trace += "D"; }
}
class Program
{
    static int checks, failures;
    public static string Trace = "";
    public static int FieldCalls;
    public static int Init(string tag, int n) { FieldCalls++; Trace += tag; return n; }
    public static int Argument() { Trace += "A"; return 7; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.First == 13 && item.Second == 19 && FieldCalls == 2, "textual-field-values");
        Check(Trace == "FSBD", "textual-field-order-before-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
