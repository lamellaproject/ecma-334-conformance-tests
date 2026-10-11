/*
Rules: E12-8-11-3-dynamic-ambiguous-indexer
Authority: ECMA-334 7th ed 12.8.11.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic second = 5;
Into: dynamic second = 5L;
*/
using System;
public class Cell
{
    public int this[int first, long second] { get { return 1; } }
    public int this[long first, int second] { get { return 2; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell receiver = new Cell(); dynamic second = 5;
        bool rejected = false;
        try { object result = receiver[3, second]; }
        catch (Exception) { rejected = true; }
        Check(rejected, "runtime-indexer-overload-ambiguity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
