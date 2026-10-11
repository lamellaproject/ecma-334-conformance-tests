/*
Rules: E23-6-3-form-member-access
Authority: ECMA-334 7th ed 23.6.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = pointer->Add<int>(4);
Into: int result = other.Add<int>(4);
*/
using System;
struct Item
{
    public int Value;
    public int Add<T>(int delta) { return Value + delta; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item(), other = new Item();
        value.Value = 19;
        Item* pointer = &value;
        int result = pointer->Add<int>(4);
        Check(result == 23, "arrow-member-type-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
