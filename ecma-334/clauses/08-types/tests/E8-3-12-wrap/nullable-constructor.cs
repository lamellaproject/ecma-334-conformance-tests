/*
Rules: E8-3-12-wrap; E8-3-12-nullable-value-constructor; E8-3-12-nullable-constructor-form; E8-3-12-nullable-nonnull-definition; E8-3-12-unwrap-value; E8-3-12-nullable-hasvalue-type; E8-3-12-nullable-value-type; E8-3-12-unwrapping-definition; E8-3-1-value-form-nullable; E8-3-1-nullable-form
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new int?(63)
Into: new int?(64)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? value = new int?(63); bool hasValue = value.HasValue; int unwrapped = value.Value;
        Check(hasValue && unwrapped == 63, "wrapped-value-properties");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
