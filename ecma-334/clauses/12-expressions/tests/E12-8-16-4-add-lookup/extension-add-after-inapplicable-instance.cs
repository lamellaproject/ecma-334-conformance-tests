/*
Rules: E12-8-16-4-add-lookup; E12-8-16-4-add-invocation; E12-8-16-4-add-overload
Authority: ECMA-334 7th ed 12.8.16.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Bag { 7 }
Into: new Bag { "bad" }
*/
using System;
using System.Collections;
class Bag : IEnumerable
{
    public int Selected, Value;
    public void Add(string value) { Selected = 2; }
    public IEnumerator GetEnumerator() { return null; }
}
static class Extensions
{
    public static void Add(this Bag bag, int value) { bag.Selected = 1; bag.Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Bag value = new Bag { 7 };
        Check(value.Selected == 1, "extension-add-after-inapplicable-instance-add");
        Check(value.Value == 7, "extension-add-receives-element-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
