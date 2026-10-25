/*
Rules: P08-index-from-end
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: Index index = ^Read();
Into: Index index = new Index(Read(), false);
*/
using System;
class Distance
{
    public static implicit operator int(Distance value)
    {
        Program.Trace += "C";
        if (Program.ThrowConversion) throw new ConversionFailure();
        return 4;
    }
}
class ConversionFailure : Exception { }
class Program
{
    public static string Trace = "";
    public static bool ThrowConversion;
    static int checks, failures;
    static Distance Read() { Trace += "E"; return new Distance(); }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Index index = ^Read();
        Check(index.Value == 4 && index.IsFromEnd, "implicit-int-operand-result");
        Check(Trace == "EC", "expression-before-single-conversion");
        Trace = "";
        ThrowConversion = true;
        bool caught = false;
        try { Index failed = ^Read(); }
        catch (ConversionFailure) { caught = true; }
        Check(caught, "conversion-exception-propagates");
        Check(Trace == "EC", "throwing-conversion-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
