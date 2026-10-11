/*
Rules: E15-6-2-6-array-normal-value-behavior; E15-6-2-6-array-normal-argument; E15-6-2-6-array-value-equivalence; E15-6-2-6-array-overload-normal-form
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Edit(source)
Into: Edit(new int[] { source[0] })
*/
using System;
class Program
{
    static int Edit(params int[] values)
    {
        values[0] += 4;
        values = new int[] { 11 };
        return values[0];
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] source = new int[] { 5 };
        int[] original = source;
        int result = Edit(source);
        Check(source[0] == 9, "normal-form-passes-existing-array-reference");
        Check(source == original, "parameter-reassignment-preserves-caller-reference");
        Check(result == 11, "reassigned-value-parameter-refers-to-new-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
