/*
Rules: E23-7-pinnable-method-initializer; E23-7-pinnable-initializer-result; E23-7-pinnable-initializer-pins
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: fixed (int* pointer = source)
Into: fixed (int* pointer = other)
*/
using System;
class Item
{
    public int Value, Calls;
    public ref int GetPinnableReference() { Calls++; return ref Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item source = new Item(), other = new Item();
        source.Value = 47; other.Value = 5;
        fixed (int* pointer = source)
        {
            Check(source.Calls == 1, "instance-pattern-called-once");
            Check(*pointer == 47, "instance-pattern-returned-variable");
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            fixed (int* actual = &source.Value) Check(pointer == actual, "pattern-address-after-collection");
            *pointer = 53;
            Check(source.Value == 53, "pattern-returned-variable-write");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
