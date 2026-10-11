/*
Rules: E23-7-pinnable-initializer-result
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return ref Value;
Into: return ref Decoy;
*/
using System;
class Item
{
    public int Decoy, Value;
    public ref int GetPinnableReference() { return ref Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item source = new Item();
        source.Decoy = 5; source.Value = 61;
        fixed (int* pointer = source)
        {
            Check(*pointer == 61, "pattern-selected-interior-value");
            fixed (int* direct = &source.Value) Check(pointer == direct, "pattern-selected-interior-address");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
