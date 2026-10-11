/*
Rules: E12-11-overload-resolution; E12-11-operand-conversions; E12-11-result-type
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: input << count
Into: input >> count
*/
using System;
struct Answer { public int Value; public Answer(int v) { Value = v; } }
class Number
{
    public int Value;
    public static Answer operator <<(Number x, int count) { Program.Trace += "L"; return new Answer(x.Value << count); }
    public static Answer operator >>(Number x, int count) { Program.Trace += "R"; return new Answer(x.Value >> count); }
}
class Narrow : Number { }
struct Count { public static implicit operator int(Count x) { Program.Trace += "C"; return 2; } }
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(Answer x) { return 1; }
    static int Kind(object x) { return 2; }
    static void Main()
    {
        Narrow input = new Narrow { Value = 12 }; Count count = new Count();
        var left = input << count; Check(left.Value == 48 && Trace == "CL", "left-conversion-and-operator");
        Check(Kind(left) == 1, "left-return-type");
        Trace = ""; var right = input >> count; Check(right.Value == 3 && Trace == "CR", "right-conversion-and-operator");
        Check(Kind(right) == 1, "right-return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
