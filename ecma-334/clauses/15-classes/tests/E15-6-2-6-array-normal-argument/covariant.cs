/*
Rules: E15-6-2-6-array-normal-argument; E15-6-2-6-array-normal-value-behavior
Authority: ECMA-334 7th ed 15.6.2.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Store(original)
Into: Store((object)original)
*/
using System;
class Token { }
class Program
{
    static object[] Echo(params object[] values) { return values; }
    static void Store(params object[] values) { values[0] = new Token(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[] original = new string[] { "seed" };
        Check(Echo(original) == original, "implicit-covariant-conversion-passes-existing-array");
        bool mismatch = false;
        try { Store(original); }
        catch (ArrayTypeMismatchException) { mismatch = true; }
        catch (Exception) { }
        Check(mismatch, "normal-argument-retains-array-element-type");
        Check(original[0] == "seed", "failed-store-preserves-caller-array-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
