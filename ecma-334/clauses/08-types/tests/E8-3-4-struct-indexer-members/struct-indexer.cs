/*
Rules: E8-3-4-struct-indexer-members
Authority: ECMA-334 7th ed 8.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return index + 11;
Into: return index + 12;
*/
using System;
struct Sample { public int this[int index] { get { return index + 11; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sample sample = new Sample();
        Check(sample[4] == 15, "struct-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
