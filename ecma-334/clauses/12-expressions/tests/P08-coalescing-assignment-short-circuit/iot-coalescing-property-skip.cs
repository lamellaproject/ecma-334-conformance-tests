/*
Rules: P08-coalescing-assignment-short-circuit; E12-21-4-getter-required; E12-21-4-setter-required
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: Obtain().Value ??= Next()
Into: Obtain().Value = Next()
*/
using System;

class Cell
{
    public object Stored;
    public object Value
    {
        get { Program.Trace += "G"; return Stored; }
        set { Program.Trace += "S"; Stored = value; }
    }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static readonly Cell cell = new Cell();
    static readonly object replacement = new object();
    static Cell Obtain() { Trace += "A"; return cell; }
    static object Next() { Trace += "R"; return replacement; }
    static object Ensure() { return Obtain().Value ??= Next(); }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object resident = new object();
        cell.Stored = resident;
        object result = Ensure();
        Check(Object.ReferenceEquals(result, resident) && Object.ReferenceEquals(cell.Stored, resident), "nonnull-value-retained");
        Check(Trace == "AG", "nonnull-skips-fallback-and-setter");
        cell.Stored = null;
        Trace = "";
        result = Ensure();
        Check(Object.ReferenceEquals(result, replacement) && Object.ReferenceEquals(cell.Stored, replacement), "null-stores-fallback-identity");
        Check(Trace == "AGRS", "null-getter-before-fallback-before-setter");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
