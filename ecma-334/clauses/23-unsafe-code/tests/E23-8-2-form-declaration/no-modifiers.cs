/*
Rules: E23-8-2-form-declaration
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return Values[0];
Into: return Values[1];
*/
using System;
unsafe struct Item
{
    fixed int Values[2];
    public int Read()
    {
        Values[0] = 41;
        Values[1] = 5;
        return Values[0];
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        Check(value.Read() == 41, "buffer-with-no-modifiers");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
