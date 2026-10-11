/*
Rules: E12-8-11-1-dynamic-argument; E12-8-11-1-array-classification
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: object[] receiver = new object[] { 3, 19 };
Into: object[] receiver = new object[] { 3, 23 };
*/
using System;
class Program
{
    static int checks, failures;
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] receiver = new object[] { 3, 19 };
        dynamic index = 1;
        var result = receiver[index];
        Check((int)result == 19 && Kind(result) == 2, "statically-array-typed-primary-keeps-object-result");
        // The int runtime value does not change the array element's static object type.
        object boxed = result;
        Check(Kind(boxed) == 2, "array-element-type-remains-known");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
