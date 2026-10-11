/*
Rules: E12-8-11-1-dynamic-primary; E12-8-11-1-dynamic-value; E12-8-11-1-dynamic-runtime-types
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver[1]
Into: receiver[0]
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
        dynamic receiver = new int[] { 3, 17 };
        var result = receiver[1];
        Check(result == 17, "dynamic-array-receiver-binds-at-runtime");
        Check(Kind(result) == 1, "dynamic-element-result-binds-next-invocation-dynamically");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
