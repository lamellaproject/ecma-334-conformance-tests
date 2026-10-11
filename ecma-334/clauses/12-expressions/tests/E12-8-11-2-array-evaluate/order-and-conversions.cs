/*
Rules: E12-8-11-2-array-evaluate; E12-8-11-2-index-order; E12-8-11-2-index-conversion-order; E12-8-11-2-index-conversion-type
Authority: ECMA-334 7th ed 12.8.11.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Fetch()[Index("A", 1), Index("B", 0)]
Into: Fetch()[Index("A", 0), Index("B", 1)]
*/
using System;
struct Offset
{
    public int number;
    public string name;
    public static implicit operator int(Offset value) { Program.trace += value.name + "i"; return value.number; }
    public static implicit operator uint(Offset value) { Program.trace += value.name + "u"; return (uint)value.number; }
    public static implicit operator long(Offset value) { Program.trace += value.name + "l"; return value.number; }
    public static implicit operator ulong(Offset value) { Program.trace += value.name + "v"; return (ulong)value.number; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static int[,] Fetch() { trace += "P"; return new int[,] { { 3, 5 }, { 7, 11 } }; }
    static Offset Index(string name, int value) { trace += name; return new Offset { name = name, number = value }; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Fetch()[Index("A", 1), Index("B", 0)];
        Check(result == 7, "converted-indices-select-element");
        Check(trace == "PAAiBBi", "receiver-then-each-index-immediately-converted-to-first-target-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
