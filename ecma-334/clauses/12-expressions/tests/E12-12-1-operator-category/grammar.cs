/*
Rules: E12-12-1-operator-category; E12-12-1-comparison-category; E12-12-1-form-shift; E12-12-1-form-less; E12-12-1-form-greater; E12-12-1-form-less-equal; E12-12-1-form-greater-equal; E12-12-1-form-is-type; E12-12-1-form-is-pattern; E12-12-1-form-as; E12-12-1-form-relational; E12-12-1-form-equality; E12-12-1-form-inequality
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: low < high
Into: low > high
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int low = 2, high = 9; object boxed = "text";
        Check(low < high, "less-form"); Check(high > low, "greater-form");
        Check(high >= low << 2, "shift-before-relational");
        Check((low <= high) == (high != low), "equality-around-relations");
        Check((low == high) != (high >= low), "inequality-form");
        Check(boxed is string, "is-type-form");
        Check(boxed is string s && s == "text", "is-pattern-form");
        Check(boxed as string == "text", "as-form");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
