/*
Rules: E15-11-3-base-constructor-runs-field-initializers
Authority: ECMA-334 7th ed 15.11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: N = Program.Init("F", 13)
Into: N = 0
*/
using System;
class Basis { public Basis() { Program.Trace += "B"; } }
class Gauge : Basis { public int N = Program.Init("F", 13); public Gauge() { Program.Trace += "D"; } }
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
        Check(item.N == 13 && FieldCalls == 1, "omitted-initializer-field-assignment");
        Check(Trace == "FBD", "omitted-initializer-field-before-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
