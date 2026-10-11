/*
Rules: E12-6-2-1-indexer-setter-argument; E12-6-2-2-indexer-value-correspondence
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: box[first: 3, second: 5] = 7;
Into: box[first: 3, second: 5] = 8;
*/
using System;
class Box
{
    public int trace;
    public int this[int first, int second] { set { trace = first * 100 + second * 10 + value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); box[first: 3, second: 5] = 7;
        Check(box.trace == 357, "indexer-arguments-then-value-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
