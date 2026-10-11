/*
Rules: E15-11-3-base-constructor-runs-field-initializers
Authority: ECMA-334 7th ed 15.11.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: : this(Program.Argument())
Into: : base()
*/
using System;
class Basis { public Basis() { Program.Trace += "B"; } }
class Gauge : Basis
{
    public int N = Program.Init("F", 19);
    public int ArgumentValue;
    public Gauge() : this(Program.Argument()) { Program.Trace += "O"; }
    private Gauge(int n) : base() { ArgumentValue = n; Program.Trace += "T"; }
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
        Check(item.N == 19 && item.ArgumentValue == 7, "this-chain-field-and-argument-values");
        Check(FieldCalls == 1, "this-chain-field-initializers-run-once");
        Check(Trace == "AFBTO", "this-argument-before-target-field-and-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
