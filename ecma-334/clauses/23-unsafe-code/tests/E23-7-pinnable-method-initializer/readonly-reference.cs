/*
Rules: E23-7-pinnable-method-initializer
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public ref readonly int GetPinnableReference()
Into: public ref readonly int Other()
*/
using System;
class Item
{
    public int Value;
    public ref readonly int GetPinnableReference() { return ref Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item source = new Item();
        source.Value = 83;
        fixed (int* pointer = source) Check(*pointer == 83, "readonly-reference-pattern");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
