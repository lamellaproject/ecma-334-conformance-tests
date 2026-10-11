/*
Rules: E15-1-indexer-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return key + 13;
Into: return key - 13;
*/
using System;
class Meter
{
    public int this[int key] { get { return key + 13; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Meter()[6] == 19, "class-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
