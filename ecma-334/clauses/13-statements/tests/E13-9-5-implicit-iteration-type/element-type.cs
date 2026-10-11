/*
Rules: E13-9-5-implicit-iteration-type; E13-9-5-iteration-variable-scope
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (var item in values)
Into: foreach (object item in values)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Select(short value) { return 1; }
    static int Select(object value) { return 2; }
    static void Main()
    {
        short[] values = new short[] { 5, 9 };
        foreach (var item in values) { Check(Select(item) == 1, "var-is-array-element-type"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
