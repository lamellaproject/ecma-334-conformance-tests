/*
Rules: E12-8-13-struct-iterator-async-copy; E12-8-13-struct-iterator-async-value
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: this = new Cell(31);
Into: Cell copy = new Cell(31);
*/
using System;
using System.Collections.Generic;
struct Cell
{
    public int Value;
    public Cell(int value) { Value = value; }
    public IEnumerator<int> Walk()
    {
        Value++;
        yield return Value;
        this = new Cell(31);
        yield return Value;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(5);
        IEnumerator<int> iterator = cell.Walk();
        cell.Value = 12;
        Check(iterator.MoveNext() && iterator.Current == 6, "iterator-captures-call-time-value");
        Check(cell.Value == 12, "iterator-field-mutation-does-not-change-original");
        Check(iterator.MoveNext() && iterator.Current == 31, "iterator-this-is-assignable-value-parameter");
        Check(cell.Value == 12, "iterator-this-replacement-does-not-change-original");
        Check(!iterator.MoveNext(), "iterator-finishes-after-both-checkpoints");
        iterator.Dispose();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
