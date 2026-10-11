/*
Rules: E12-8-16-3-indexer-arguments-once
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [At()] = { },
Into: [4] = { },
*/
using System;
class Leaf { public int First, Second; }
class Table
{
    public Leaf Node = new Leaf();
    public bool WrongKey;
    public Leaf this[int key] { get { if (key != 4) WrongKey = true; return Node; } }
}
class Program
{
    static int calls;
    static int At() { calls++; return calls * 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Table value = new Table { [At()] = { }, [At()] = { First = 17, Second = 19 } };
        Check(calls == 2, "index-argument-once-even-for-empty-initializer");
        Check(!value.WrongKey, "nested-assignments-reuse-evaluated-index-argument");
        Check(value.Node.First == 17 && value.Node.Second == 19, "nested-index-members-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
