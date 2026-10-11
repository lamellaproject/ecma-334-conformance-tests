/*
Rules: E12-8-11-1-indexer-classification; E12-8-11-3-classification; E12-8-11-3-selected-reference; E12-8-11-3-associated-instance; E12-8-11-3-associated-arguments; E12-8-11-3-associated-type; E12-8-11-3-assignment-set; E12-8-11-3-other-get
Authority: ECMA-334 7th ed 12.8.11
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: left[3]
Into: left[5]
*/
using System;
interface ICell { int this[int index] { get; set; } }
class Cell : ICell { public int stored; public int this[int index] { get { return stored + index; } set { stored = value - index; } } }
struct ValueCell { public int stored; public int this[int index] { get { return stored + index; } set { stored = value - index; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell left = new Cell(), right = new Cell();
        left.stored = 11; right.stored = 19;
        Check(left[3] == 14 && right[3] == 22, "indexer-instance-and-argument-are-associated");
        left[2] = 31;
        Check(left.stored == 29 && right.stored == 19, "indexer-assignment-invokes-associated-instance-setter");
        ICell view = left;
        Check(view[1] == 30, "interface-value-has-indexer-getter");
        ValueCell value = new ValueCell(); value[4] = 41;
        Check(value[1] == 38 && value.stored == 37, "struct-variable-indexer-setter-updates-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
