/*
Rules: E15-3-10-4-reserve-indexer-get; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: public int get_Item(long index)
Into: public int get_Item(int index)
*/
using System;
class Gauge
{
    public int this[int index] { get { return 569; } }
    public int get_Item(long index) { return 571; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
