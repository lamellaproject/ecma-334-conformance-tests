/*
Rules: E23-7-pinnable-extension-initializer
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static ref int GetPinnableReference(this Item item)
Into: public static ref int Other(this Item item)
*/
using System;
class Item { public int Value, Calls; }
static class Pins
{
    public static ref int GetPinnableReference(this Item item) { item.Calls++; return ref item.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item source = new Item();
        source.Value = 71;
        fixed (int* pointer = source)
        {
            Check(*pointer == 71, "extension-pattern-value");
            Check(source.Calls == 1, "extension-pattern-called-once");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
