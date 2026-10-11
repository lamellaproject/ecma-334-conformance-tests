/*
Rules: E9-4-4-24-collection-initializer-state
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = 3), cell + 1
Into: 3, cell + 1
*/
using System;
using System.Collections;
class Bag : IEnumerable
{
    public int Total;
    public void Add(int value) { Total = Total * 10 + value; }
    public IEnumerator GetEnumerator() { return new int[0].GetEnumerator(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        Bag value = new Bag { (cell = 3), cell + 1 };
        Check(value.Total == 34, "add-call-order-propagates-assignment");
        Check(cell == 3, "collection-initializer-exit-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
