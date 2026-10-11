/*
Rules: E12-10-2-overload-resolution; E12-10-2-operand-conversions; E12-10-2-result-type
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: left * right
Into: new Answer(0)
*/
using System;
struct Answer { public int Value; public Answer(int v) { Value = v; } }
class Number
{
    public int Value;
    public static Answer operator *(Number x, int y) { Program.Trace += "M"; return new Answer(x.Value * y); }
    public static Answer operator *(Number x, long y) { return new Answer(-1); }
}
class Narrow : Number { }
struct Input
{
    public static implicit operator int(Input x) { Program.Trace += "C"; return 4; }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Answer x) { return 1; }
    static int Kind(object x) { return 2; }
    static void Main()
    {
        Narrow left = new Narrow { Value = 19 }; Input right = new Input(); var result = left * right;
        Check(result.Value == 76, "better-int-operator");
        Check(Trace == "CM", "convert-before-operator");
        Check(Kind(result) == 1, "return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
