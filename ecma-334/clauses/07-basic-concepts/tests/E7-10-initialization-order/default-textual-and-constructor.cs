/*
Rules: E7-10-initialization-order
Authority: ECMA-334 7th ed 7.10
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static int first = Record(1), second = Record(2);
Into: static int second = Record(2), first = Record(1);
*/
using System;
class Sequence
{
    public static int Trace;
    public static int Record(int value) { Trace = Trace * 10 + value; return value; }
}
class StaticCell
{
    static int first = Record(1), second = Record(2);
    public static int PriorSecond;
    static int Record(int value)
    {
        if (value == 1) PriorSecond = second;
        return Sequence.Record(value);
    }
    static StaticCell() { Sequence.Record(3); }
    public static int Read() { return first + second; }
}
class InstanceCell
{
    public int First = Sequence.Record(4), Second = Sequence.Record(5);
    public InstanceCell() { Sequence.Record(6); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sequence.Trace = 0;
        int total = StaticCell.Read();
        Check(StaticCell.PriorSecond == 0, "default-initialization-precedes-static-initializers");
        Check(total == 3 && Sequence.Trace == 123, "textual-static-initializers-precede-static-constructor");
        InstanceCell instance = new InstanceCell();
        Check(instance.First == 4 && instance.Second == 5, "instance-initializer-values-preserved");
        Check(Sequence.Trace == 123456, "textual-instance-initializers-precede-constructor-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
