/*
Rules: E23-8-2-form-element-type
Authority: ECMA-334 7th ed 23.8.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public fixed Element Values[2];
Into: public fixed byte Values[2];
*/
using System;
using Element = System.Int32;
unsafe struct Item { public fixed Element Values[2]; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        int* pointer = value.Values;
        pointer[1] = 37;
        Check(value.Values[1] == 37, "aliased-predefined-element-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
