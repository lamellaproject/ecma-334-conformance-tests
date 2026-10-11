/*
Rules: E23-7-buffer-simple-initializer
Authority: ECMA-334 7th ed 23.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: fixed (short* pointer = Values)
Into: fixed (short* pointer = Other)
*/
using System;
unsafe struct Item
{
    public fixed short Values[2];
    public fixed short Other[2];
    public void Write()
    {
        fixed (short* pointer = Values) { pointer[0] = 19; pointer[1] = 23; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.Write();
        Check(value.Values[0] == 19, "simple-buffer-first-element");
        Check(value.Values[1] == 23, "simple-buffer-final-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
