/*
Rules: E12-8-16-5-initializer-exception; E12-8-16-5-initializer-assignment
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Read("B", "b", true)
Into: Read("B", "b", false)
*/
using System;
class Marker : Exception { }
struct Source
{
    public string Tag;
    public bool Stop;
    public static implicit operator Cell(Source value)
    {
        Program.Trace += value.Tag;
        if (value.Stop) throw new Marker();
        return new Cell();
    }
}
struct Cell { }
class Program
{
    public static string Trace = "";
    static Source Read(string evaluation, string conversion, bool stop)
    {
        Trace += evaluation;
        return new Source { Tag = conversion, Stop = stop };
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell[] old = new Cell[1];
        Cell[] cells = old;
        bool caught = false;
        try
        {
            cells = new Cell[3] { Read("A", "a", false), Read("B", "b", true), Read("C", "c", false) };
        }
        catch (Marker) { caught = true; }
        catch (Exception) { }
        Check(caught, "initializer-conversion-exception");
        Check(Trace == "AaBb", "conversion-throw-stops-later-elements");
        Check(object.ReferenceEquals(cells, old), "failed-element-conversion-no-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
