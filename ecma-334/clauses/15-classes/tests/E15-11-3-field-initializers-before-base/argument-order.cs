/*
Rules: E15-11-3-field-initializers-before-base; E15-11-3-base-constructor-runs-field-initializers
Authority: ECMA-334 7th ed 15.11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int N = Program.Init("F", 19); public Gauge() : base(Program.Argument()) { Program.Trace += "D"; }
Into: public int N; public Gauge() : base(Program.Argument()) { N = Program.Init("F", 19); Program.Trace += "D"; }
*/
using System;
class Basis { public int ArgumentValue; public Basis(int n) { ArgumentValue = n; Program.Trace += "B"; } }
class Gauge : Basis { public int N = Program.Init("F", 19); public Gauge() : base(Program.Argument()) { Program.Trace += "D"; } }
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
        Check(item.N == 19 && item.ArgumentValue == 7, "base-initializer-field-and-argument-values");
        Check(Trace == "FABD", "field-before-base-argument-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
