/*
Rules: E12-6-6-1-value-instance-evaluation; E12-6-6-1-value-arguments; E12-6-6-1-value-invoke; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: values[Index()].Advance(Argument())
Into: values[0].Advance(Argument())
*/
using System;
struct Cell
{
    public int value;
    public int Advance(int amount) { Program.trace = Program.trace * 10 + 3; value += amount; return value; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Index() { trace = trace * 10 + 1; return 0; }
    static int Argument() { trace = trace * 10 + 2; return 4; }
    static void Main()
    {
        Cell[] values = new Cell[] { new Cell { value = 3 } };
        int result = values[Index()].Advance(Argument());
        Check(trace == 123, "value-receiver-before-argument-before-body");
        Check(result == 7, "value-member-result");
        Check(values[0].value == 7, "this-aliases-writable-array-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
