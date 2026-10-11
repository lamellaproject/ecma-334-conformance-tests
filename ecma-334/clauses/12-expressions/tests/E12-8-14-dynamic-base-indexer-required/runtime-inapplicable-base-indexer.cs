/*
Rules: E12-8-14-dynamic-base-indexer-required
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/runtime-inapplicable-base-indexer-1d9635161b.cs.part
Mutate: base[index]
Into: base[0]
*/
using System;
class Root { public int this[int index] { get { Program.reads++; return index; } } }
class Leaf : Root { public int Read(dynamic index) { return base[index]; } }
public class Program
{
    public static int reads;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool rejected = false;
        try { new Leaf().Read("fir"); }
        catch (Exception) { rejected = true; }
        Check(rejected, "inapplicable-base-indexer-fails-at-runtime-binding");
        Check(reads == 0, "inapplicable-base-indexer-never-invokes-getter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
