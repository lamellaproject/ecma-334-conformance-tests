/*
Rules: E15-9-2-indexer-always-instance
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int this[int index]
Into: public static int this[int index]
*/
using System;
class Grid { int offset; public Grid(int value) { offset = value; } public int this[int index] => offset + index; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Grid(5)[2] == 7, "first-indexer-instance");
        Check(new Grid(11)[2] == 13, "second-indexer-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
