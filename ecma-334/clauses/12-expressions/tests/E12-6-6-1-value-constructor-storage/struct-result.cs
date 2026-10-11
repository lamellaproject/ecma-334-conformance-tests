/*
Rules: E12-6-6-1-value-constructor-storage; E12-6-6-1-value-invoke; E12-6-6-1-constructor-result
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Cell(Argument())
Into: default(Cell)
*/
using System;
struct Cell
{
    public int value;
    public Cell(int value) { this = default(Cell); this.value = value; Program.trace = Program.trace * 10 + 2; }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Argument() { trace = trace * 10 + 1; return 3; }
    static void Main()
    {
        Cell result = new Cell(Argument());
        Check(trace == 12, "struct-constructor-arguments-before-body");
        Check(result.value == 3, "struct-constructor-this-writes-result-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
