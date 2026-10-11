/*
Rules: E12-8-16-5-dimension-exception; E12-8-16-5-dimension-conversion-order
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new int[Read("A", "a", true), Read("B", "b", false)]
Into: new int[Read("A", "a", false), Read("B", "b", false)]
*/
using System;
class Marker : Exception { }
struct Length
{
    public string Tag;
    public bool Stop;
    public static implicit operator int(Length value)
    {
        Program.Trace += value.Tag;
        if (value.Stop) throw new Marker();
        return 2;
    }
}
class Program
{
    public static string Trace = "";
    static Length Read(string evaluation, string conversion, bool stop)
    {
        Trace += evaluation;
        return new Length { Tag = conversion, Stop = stop };
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[,] old = new int[1, 1];
        int[,] cells = old;
        bool caught = false;
        try { cells = new int[Read("A", "a", true), Read("B", "b", false)]; }
        catch (Marker) { caught = true; }
        catch (Exception) { }
        Check(caught, "dimension-conversion-exception");
        Check(Trace == "Aa", "conversion-throw-prevents-next-evaluation");
        Check(object.ReferenceEquals(cells, old), "failed-conversion-no-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
