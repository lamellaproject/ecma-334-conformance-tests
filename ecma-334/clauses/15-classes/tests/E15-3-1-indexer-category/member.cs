/*
Rules: E15-3-1-indexer-category; E15-3-1-grammar-class-member-declaration-form-6
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int this[int index]
Into: public int this[long index, int unused]
*/
using System;
class Slots
{
    int[] values = new int[2];
    public int this[int index]
    {
        get { return values[index]; }
        set { values[index] = value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Slots value = new Slots();
        value[0] = 131;
        value[1] = 137;
        Check(value[0] == 131, "class-indexed-first-slot");
        Check(value[1] == 137, "class-indexed-second-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
