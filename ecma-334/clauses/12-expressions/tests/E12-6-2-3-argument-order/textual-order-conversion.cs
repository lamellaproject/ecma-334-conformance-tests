/*
Rules: E12-6-2-3-argument-order; E12-6-2-3-value-evaluation; E12-6-2-3-value-initialization
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Pack(second: Evaluate(1), first: Evaluate(2))
Into: Pack(first: Evaluate(1), second: Evaluate(2))
*/
using System;
struct Box
{
    public int value;
    public Box(int n) { value = n; }
    public static implicit operator int(Box item) { Program.trace = Program.trace * 10 + 3; return item.value; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static Box Evaluate(int tag) { trace = trace * 10 + tag; return new Box(tag + 10); }
    static int Pack(int first, int second) { return first * 100 + second; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Pack(second: Evaluate(1), first: Evaluate(2));
        Check(result == 1211, "converted-values-initialized-corresponding-parameters");
        Check(trace == 1323, "textual-evaluation-and-conversion-interleaved");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
