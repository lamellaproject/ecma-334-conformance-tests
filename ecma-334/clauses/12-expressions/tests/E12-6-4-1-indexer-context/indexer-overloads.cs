/*
Rules: E12-6-4-1-indexer-context
Authority: ECMA-334 7th ed 12.6.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: box[(short)8]
Into: box[8L]
*/
using System;
class Box
{
    public int this[int x] { get { return 1; } }
    public int this[long x] { get { return 2; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        Check(box[(short)8] == 1, "indexer-better-target-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
