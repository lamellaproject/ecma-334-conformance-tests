/*
Rules: E12-6-3-1-each-generic-method; E12-6-3-1-omitted-type-arguments; E12-6-3-1-inference-before-overload; E12-6-3-1-inferred-overload-types; E12-6-3-1-inferred-invocation-types; E12-6-3-1-unique-valid-type-arguments; E12-6-3-3-all-fixed-success
Authority: ECMA-334 7th ed 12.6.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Take(new int[] { 17 })
Into: Take(new long[] { 17 })
*/
using System;
class Program
{
    static int checks, failures;
    static T Take<T>(T item) { return item; }
    static T Take<T>(T[] items) { return items[0]; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int item = Take(new int[] { 17 });
        Check(item == 17, "array-candidate-infers-element-type-before-comparison");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
