/*
Rules: E12-8-16-3-nested-collection-add; E12-8-16-3-nested-value-form
Authority: ECMA-334 7th ed 12.8.16.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Items = { 7, 11 }
Into: Items = new Bag { 7, 11 }
*/
using System;
using System.Collections;
class Bag : IEnumerable
{
    public int Count, Sum;
    public void Add(int value) { Count++; Sum += value; }
    public IEnumerator GetEnumerator() { return null; }
}
class Shell
{
    public Bag Items;
    public Bag Remembered;
    public Shell() { Items = new Bag(); Items.Add(5); Remembered = Items; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Shell value = new Shell { Items = { 7, 11 } };
        Check(object.ReferenceEquals(value.Items, value.Remembered), "nested-collection-keeps-original-reference");
        Check(value.Items.Count == 3 && value.Items.Sum == 23, "nested-collection-adds-after-existing-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
