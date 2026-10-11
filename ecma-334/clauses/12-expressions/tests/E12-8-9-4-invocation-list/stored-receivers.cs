/*
Rules: E12-8-9-4-invocation-list; E12-8-9-4-stored-instance
Authority: ECMA-334 7th ed 12.8.9.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: operations += right.Apply;
Into: operations += left.Apply;
*/
using System;
delegate int Operation(int value);
class Cell
{
    public string name;
    public int total;
    public Cell(string name) { this.name = name; }
    public int Apply(int value) { Program.trace += name; total += value; return total; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell left = new Cell("L"), right = new Cell("R");
        right.total = 10;
        Operation operations = left.Apply;
        operations += right.Apply;
        int result = operations(7);
        Check(trace == "LR", "delegate-invokes-each-entity-in-order");
        Check(left.total == 7 && right.total == 17, "each-entity-uses-its-stored-instance");
        Check(result == 17, "last-entity-result-returned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
