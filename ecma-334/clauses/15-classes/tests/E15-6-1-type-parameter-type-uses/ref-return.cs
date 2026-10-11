/*
Rules: E15-6-1-type-parameter-type-uses; E15-6-1-method-parameter-scope
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public static ref T Cell<T>(T[] values) { return ref values[0]; }
Into: public static ref T Cell<T>(T[] values) { return ref values[1]; }
*/
using System;
class Selector { public static ref T Cell<T>(T[] values) { return ref values[0]; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] items = { 3, 5 };
        ref int alias = ref Selector.Cell<int>(items);
        alias = 67;
        Check(items[0] == 67 && items[1] == 5, "method-type-parameter-forms-ref-return-and-parameter-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
