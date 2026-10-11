/*
Rules: E15-3-3-instance-member-this
Authority: ECMA-334 7th ed 15.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Cell<T> Self { get { return this; } }
Into: public Cell<T> Self { get { return new Cell<T>(); } }
*/
using System;
class Cell<T> { public Cell<T> Self { get { return this; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell<int> value = new Cell<int>();
        Cell<int> self = value.Self;
        Check((object)self == (object)value, "property-accessor-this-is-containing-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
