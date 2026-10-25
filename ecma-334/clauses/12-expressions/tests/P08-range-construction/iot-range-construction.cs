/*
Rules: P08-range-construction; E12-4-1-operand-order
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 6
Mutate: Range pair = Make(2, false, "a")..Make(5, true, "b");
Into: Range pair = Make(3, false, "a")..Make(5, true, "b");
*/
using System;
struct Bound
{
    public int Value;
    public bool FromEnd;
    public static implicit operator Index(Bound value)
    {
        Test.trace += "c";
        return new Index(value.Value, value.FromEnd);
    }
}
class Test
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static Bound Make(int value, bool fromEnd, string marker)
    {
        trace += marker;
        return new Bound { Value = value, FromEnd = fromEnd };
    }
    static int Main()
    {
        Range pair = Make(2, false, "a")..Make(5, true, "b");
        Check(pair.Start.Value == 2, "start-value");
        Check(!pair.Start.IsFromEnd, "start-direction");
        Check(pair.End.Value == 5, "end-value");
        Check(pair.End.IsFromEnd, "end-direction");
        Check(trace == "acbc", "operand-and-conversion-order-once");
        Range reversed = 6..1;
        Check(reversed.Start.Value == 6 && reversed.End.Value == 1, "abstract-reversed-endpoints-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
