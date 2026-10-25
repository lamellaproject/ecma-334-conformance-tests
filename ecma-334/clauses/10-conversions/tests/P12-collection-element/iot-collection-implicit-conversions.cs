/*
Rules: P12-collection-element; P12-collection-array
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: long[] values = [Make(1), Make(2)];
Into: long[] values = [0L, 0L];
*/
using System;
struct Portion
{
    public static int Conversions, Seen;
    readonly int code;
    public Portion(int code) { this.code = code; }
    public static implicit operator int(Portion value)
    {
        Conversions++; Seen |= 1 << value.code; return value.code * 23;
    }
}
class Program
{
    static int checks, failures, trace;
    static Portion Make(int code) { trace = trace * 10 + code; return new Portion(code); }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        long[] values = [Make(1), Make(2)];
        Check(values.Length == 2 && values[0] == 23L && values[1] == 46L, "converted-element-values");
        Check(trace == 12, "source-expression-order");
        Check(Portion.Conversions == 2 && Portion.Seen == 6, "user-conversions-once-per-element");
        byte[] constants = [127, 255];
        Check(constants.Length == 2 && constants[0] == 127 && constants[1] == 255, "implicit-constant-narrowing");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
