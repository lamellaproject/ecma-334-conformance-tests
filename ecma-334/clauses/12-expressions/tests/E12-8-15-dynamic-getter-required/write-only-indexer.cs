/*
Rules: E12-8-15-dynamic-getter-required
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int this[int index] { set { Program.sets++; } }
Into: public int this[int index] { get { return 3; } set { Program.sets++; } }
*/
using System;
public class Cell { public int this[int index] { set { Program.sets++; } } }
public class Program
{
    public static int sets;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic cell = new Cell(); bool rejected = false;
        try { cell[0]--; } catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-postfix-indexer-requires-getter");
        Check(sets == 0, "missing-indexer-getter-prevents-setter-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
