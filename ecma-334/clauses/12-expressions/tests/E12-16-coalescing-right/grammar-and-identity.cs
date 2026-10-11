/*
Rules: E12-16-coalescing-right; E12-16-form; E12-16-thrown-value; E12-15-form-throw
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: throw first ?? saved
Into: throw new Exception()
*/
using System;
class Program
{
    static string Left(string value) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception first = null, saved = new Exception();
        string a = Left("kept") ?? throw saved; Check(a == "kept", "nonnull-skips-throw");
        try { string b = Left(null) ?? throw first ?? saved; Check(false, "null-left-must-throw"); }
        catch (Exception e) { Check(object.ReferenceEquals(e, saved), "throw-coalescing-operand-and-identity"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
