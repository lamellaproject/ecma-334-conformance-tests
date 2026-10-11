/*
Rules: E12-8-16-5-dimension-conversion-order; E12-8-16-5-dimension-order
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new int[Read("A", "a", 2), Read("B", "b", 3)]
Into: new int[Read("B", "b", 3), Read("A", "a", 2)]
*/
using System;
struct Length
{
    public string Tag;
    public int Value;
    public static implicit operator int(Length value) { Program.Trace += value.Tag; return value.Value; }
}
class Program
{
    public static string Trace = "";
    static Length Read(string evaluation, string conversion, int value)
    {
        Trace += evaluation;
        return new Length { Tag = conversion, Value = value };
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new int[Read("A", "a", 2), Read("B", "b", 3)];
        Check(Trace == "AaBb", "dimension-evaluation-conversion-interleaving");
        Check(cells.GetLength(0) == 2 && cells.GetLength(1) == 3, "converted-dimension-lengths");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
