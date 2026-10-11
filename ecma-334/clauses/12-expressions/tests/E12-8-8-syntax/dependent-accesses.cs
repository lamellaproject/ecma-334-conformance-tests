/*
Rules: E12-8-8-syntax; E12-8-8-dependent-member-form; E12-8-8-dependent-element-form; E12-8-8-dependent-invocation-form
Authority: ECMA-334 7th ed 12.8.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int? result = root?.Self<Cell>().Items[Index()].Read<int>(Argument());
Into: int? result = root?.Self<Cell>().Items[Index()].Read<int>(0);
*/
using System;
class Leaf { public int Read<T>(int value) { Program.trace += "M"; return value + 5; } }
class Cell
{
    public Leaf[] Items { get { Program.trace += "P"; return new Leaf[] { new Leaf() }; } }
    public Cell Self<T>() { Program.trace += "S"; return this; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static int Index() { trace += "I"; return 0; }
    static int Argument() { trace += "A"; return 7; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell root = new Cell();
        int? result = root?.Self<Cell>().Items[Index()].Read<int>(Argument());
        Check(result == 12 && trace == "SPIAM", "dependent-access-forms-and-order");
        trace = "";
        root = null;
        result = root?.Self<Cell>().Items[Index()].Read<int>(Argument());
        Check(!result.HasValue && trace == "", "null-skips-all-dependent-accesses");
        root = new Cell();
        Check(root?.Self<int>().Self<string>() == root, "empty-dependent-invocation-and-type-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
