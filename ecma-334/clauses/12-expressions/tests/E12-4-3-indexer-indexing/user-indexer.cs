/*
Rules: E12-4-3-indexer-indexing
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: box[4]
Into: box[5]
*/
using System;
class Box { public int this[int index] { get { return 13 + index; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); int result = box[4];
        Check(result == 17, "user-defined-indexing");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
