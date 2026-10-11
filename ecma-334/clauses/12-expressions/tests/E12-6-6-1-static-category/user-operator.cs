/*
Rules: E12-6-6-1-static-category; E12-6-6-1-static-arguments; E12-6-6-1-static-invoke
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Make(1) + Make(2)
Into: Make(2) + Make(1)
*/
using System;
struct Cell
{
    public int value;
    public static int operator +(Cell first, Cell second)
    {
        Program.trace = Program.trace * 10 + 3;
        return first.value * 10 + second.value;
    }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Cell Make(int id) { trace = trace * 10 + id; return new Cell { value = id }; }
    static void Main()
    {
        int result = Make(1) + Make(2);
        Check(trace == 123, "operator-operands-evaluated-before-static-operator-body");
        Check(result == 12, "operator-receives-operand-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
