/*
Rules: E12-8-12-syntax; E12-8-12-nonnullable-target-type; E12-8-12-nonnullable-lift-present; E12-8-12-nonnullable-lift-null
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int? result = values?[Index()].Next.Read<int>(Argument());
Into: int? result = values?[Index()].Next.Read<int>(0);
*/
using System;
class Cell
{
    public Cell Next { get { Program.trace += "P"; return this; } }
    public int Read<T>(int value) { Program.trace += "M"; return value + 61; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static int Index() { trace += "I"; return 0; }
    static int Argument() { trace += "A"; return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell[] values = new Cell[] { new Cell() };
        int? result = values?[Index()].Next.Read<int>(Argument());
        Check(result == 63 && trace == "IPAM", "dependent-access-result-type-and-evaluation");
        trace = ""; values = null;
        result = values?[Index()].Next.Read<int>(Argument());
        Check(!result.HasValue && trace == "", "null-element-access-skips-all-dependent-accesses");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
