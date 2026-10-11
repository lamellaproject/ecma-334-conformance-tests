/*
Rules: E12-10-4-overload-resolution; E12-10-4-operand-conversions; E12-10-4-result-type
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: left % right
Into: new Answer(0)
*/
using System;
struct Answer { public int Value; public Answer(int v) { Value = v; } }
class Number
{
    public int Value;
    public static Answer operator %(Number x, int y) { Program.Trace += "R"; return new Answer(x.Value % y); }
    public static Answer operator %(Number x, long y) { return new Answer(-1); }
}
class Narrow : Number { }
struct Input { public static implicit operator int(Input x) { Program.Trace += "C"; return 4; } }
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Answer x) { return 1; }
    static int Kind(object x) { return 2; }
    static void Main()
    {
        Narrow left = new Narrow { Value = 19 }; Input right = new Input(); var result = left % right;
        Check(result.Value == 3, "better-int-operator"); Check(Trace == "CR", "conversion-order");
        Check(Kind(result) == 1, "return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
