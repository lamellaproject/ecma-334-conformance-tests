/*
Rules: E15-2-7-partial-multiple-parts
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial interface IReader { int Right(); }
Into: partial interface IOther { int Right(); }
*/
using System;
partial interface IReader { int Left(); }
partial interface IReader { int Right(); }
class Reader : IReader
{
    public int Left() { return 53; }
    public int Right() { return 59; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IReader value = new Reader();
        Check(value.Left() == 53, "interface-first-part");
        Check(value.Right() == 59, "interface-second-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
