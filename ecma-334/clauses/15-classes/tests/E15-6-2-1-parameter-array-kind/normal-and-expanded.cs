/*
Rules: E15-6-2-1-parameter-array-kind; E15-6-2-1-grammar-formal-parameter-list-form-3; E15-6-2-1-grammar-parameter-array; E15-6-2-1-parameter-array-type-name; E15-6-2-1-parameter-array-normal-argument; E15-6-2-1-parameter-array-expanded-arguments; E15-6-2-1-omitted-params-empty-array
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: static int[] Echo(params int[] values)
Into: static int[] Echo(int[] values)
*/
using System;
class Program
{
    static int[] Echo(params int[] values) { return values; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] original = { 2, 3 };
        int[] normal = Echo(original);
        Check(normal == original, "normal-params-argument-is-specified-array");
        Check(normal.Length == 2 && normal[0] == 2 && normal[1] == 3, "normal-params-argument-values");
        int[] expanded = Echo(5, 7);
        Check(expanded.Length == 2, "expanded-params-element-count");
        Check(expanded[0] == 5 && expanded[1] == 7, "expanded-params-element-values");
        int[] empty = Echo();
        Check(empty != null && empty.Length == 0, "omitted-params-is-empty-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
