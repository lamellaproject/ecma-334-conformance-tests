/*
Rules: E17-1-elements; E17-4-element-access-form; E17-4-index-int; E17-4-variable-result
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref values[index]
Into: ref index
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Store(ref int destination) { destination = 32; }
    static void Main()
    {
        int[] values = new int[3]; int index = 1;
        Store(ref values[index]);
        Check(values[1] == 32, "element-variable");
        Check(index == 1, "computed-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
