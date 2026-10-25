/*
Rules: P08-coalescing-assignment-short-circuit; E12-21-4-evaluate-left-once; E12-21-4-reuse-left-components
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: Pick()[Index()] ??= Next()
Into: Pick()[Index()] = Pick()[Index()] ?? Next()
*/
using System;

class Slots
{
    public object Stored;
    public object this[int index]
    {
        get { Program.Trace += "G"; return Stored; }
        set { Program.Trace += "S"; Stored = value; }
    }
}
class Program
{
    public static string Trace = "";
    static int checks, failures;
    static readonly Slots slots = new Slots();
    static readonly object replacement = new object();
    static Slots Pick() { Trace += "A"; return slots; }
    static int Index() { Trace += "I"; return 0; }
    static object Next() { Trace += "R"; return replacement; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object result = (Pick()[Index()] ??= Next());
        Check(Trace == "AIGRS", "receiver-index-getter-fallback-setter-once");
        Check(Object.ReferenceEquals(slots.Stored, replacement), "captured-storage-is-written");
        Check(Object.ReferenceEquals(result, replacement), "indexed-result-is-stored-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
