/*
Rules: E12-8-16-5-negative-runtime-length; E12-8-16-5-dimension-order; E12-8-16-5-dimension-conversion-order
Authority: ECMA-334 7th ed 12.8.16.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Read("A", "a", -1)
Into: Read("A", "a", 1)
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
        int[,] old = new int[1, 1];
        int[,] cells = old;
        bool caught = false;
        try { cells = new int[Read("A", "a", -1), Read("B", "b", 2)]; }
        catch (OverflowException) { caught = true; }
        catch (Exception) { }
        Check(caught, "negative-dimension-overflow");
        Check(Trace == "AaBb", "all-dimensions-before-negative-validation");
        Check(object.ReferenceEquals(cells, old), "negative-dimension-no-array-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
