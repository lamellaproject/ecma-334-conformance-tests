/*
Rules: E12-8-11-3-dynamic-applicable-indexer; E12-8-11-3-dynamic-no-indexer
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic index = "willow";
Into: dynamic index = 5;
*/
using System;
public class Cell { public int this[int index] { get { Program.reads++; return index; } } }
public class Program
{
    public static int reads;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell receiver = new Cell(); dynamic index = "willow";
        bool rejected = false;
        try { object result = receiver[index]; }
        catch (Exception) { rejected = true; }
        Check(rejected, "inapplicable-runtime-indexer-binding-error");
        Check(reads == 0, "no-getter-invoked-on-binding-failure");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
