/*
Rules: E12-8-16-5-initializer-order; E12-8-16-5-initializer-evaluation; E12-8-16-5-initializer-assignment
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Read("A", "a", 7), Read("B", "b", 19)
Into: Read("B", "b", 19), Read("A", "a", 7)
*/
using System;
struct Source
{
    public string Tag;
    public int Value;
    public static implicit operator Cell(Source value)
    {
        Program.Trace += value.Tag;
        return new Cell { Value = value.Value };
    }
}
struct Cell { public int Value; }
class Program
{
    public static string Trace = "";
    static Source Read(string evaluation, string conversion, int value)
    {
        Trace += evaluation;
        return new Source { Tag = conversion, Value = value };
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var cells = new Cell[,]
        {
            { Read("A", "a", 7), Read("B", "b", 19) },
            { Read("C", "c", 23), Read("D", "d", 29) }
        };
        Check(Trace == "AaBbCcDd", "initializer-each-evaluation-then-conversion");
        bool indices = cells[0, 0].Value == 7 && cells[0, 1].Value == 19 &&
                       cells[1, 0].Value == 23 && cells[1, 1].Value == 29;
        Check(indices, "rightmost-index-first");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
