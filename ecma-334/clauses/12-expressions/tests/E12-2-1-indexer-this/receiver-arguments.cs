/*
Rules: E12-2-1-indexer-this; E12-2-1-indexer-type; E12-2-1-indexer-instance; E12-2-1-indexer-arguments; E12-2-1-indexer-parameters; E12-2-2-indexer-getter; E12-6-1-category-indexers
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Receiver()[Argument()]
Into: other[Argument()]
*/
using System;
class Box
{
    public int raw, gets;
    public Box(int value) { raw = value; }
    public int this[int index] { get { gets++; return this.raw + index; } }
}
class Program
{
    static int checks, failures, trace;
    static Box chosen = new Box(30), other = new Box(40);
    static Box Receiver() { trace = trace * 10 + 1; return chosen; }
    static int Argument() { trace = trace * 10 + 2; return 6; }
    static int Choose(int value) { return value; }
    static int Choose(object value) { return -1; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Choose(Receiver()[Argument()]);
        Check(result == 36, "indexer-type-this-parameter");
        Check(trace == 12 && chosen.gets == 1 && other.gets == 0, "indexer-evaluation-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
