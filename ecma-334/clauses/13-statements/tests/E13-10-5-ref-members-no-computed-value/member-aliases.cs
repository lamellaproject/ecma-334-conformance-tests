/*
Rules: E13-10-5-ref-members-no-computed-value; E13-10-5-form-return-by-ref; E13-10-5-return-ref-result
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return ref other;
Into: return ref storage;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int storage = 11, other = 17;
    static ref int Method() { return ref storage; }
    static ref int Property { get { return ref other; } }
    static void Main()
    {
        ref int method = ref Method();
        method = 31;
        Check(storage == 31, "ref-method-result-is-variable");
        ref int property = ref Property;
        property = 37;
        Check(other == 37 && storage == 31, "ref-getter-result-is-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
