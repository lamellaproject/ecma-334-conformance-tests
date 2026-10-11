/*
Rules: E12-8-15-dynamic-setter-required
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int this[int index] { get { return 3; } }
Into: public int this[int index] { get { return 3; } set { } }
*/
using System;
public class Cell { public int this[int index] { get { return 3; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic cell = new Cell(); bool rejected = false;
        try { cell[0]--; } catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-postfix-indexer-requires-setter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
