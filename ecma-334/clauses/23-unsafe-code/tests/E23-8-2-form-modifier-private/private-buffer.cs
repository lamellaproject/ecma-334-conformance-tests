/*
Rules: E23-8-2-form-modifier-private; E23-8-2-buffer-accessibility
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return pointer[0];
Into: return pointer[1];
*/
using System;
unsafe struct Item
{
    private fixed int Values[2];
    public int Read()
    {
        fixed (int* pointer = Values)
        {
            pointer[0] = 31;
            pointer[1] = 5;
            return pointer[0];
        }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        Check(value.Read() == 31, "private-buffer-access-within-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
