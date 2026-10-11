/*
Rules: E12-6-6-1-value-instance-exception; E12-6-6-1-value-instance-evaluation
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Receiver().Advance(Argument())
Into: new Cell().Advance(Argument())
*/
using System;
struct Cell
{
    public int Advance(int amount) { Program.trace = Program.trace * 10 + 3; return amount; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Cell Receiver() { trace = trace * 10 + 1; throw new InvalidOperationException(); }
    static int Argument() { trace = trace * 10 + 2; return 4; }
    static void Main()
    {
        bool caught = false;
        try { Receiver().Advance(Argument()); }
        catch (InvalidOperationException) { caught = true; }
        catch (Exception) { }
        Check(caught, "value-receiver-exception-propagates");
        Check(trace == 1, "value-receiver-exception-skips-arguments-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
