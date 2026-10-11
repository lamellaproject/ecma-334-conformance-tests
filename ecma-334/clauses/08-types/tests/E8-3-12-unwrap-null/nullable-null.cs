/*
Rules: E8-3-12-unwrap-null; E8-3-12-nullable-null-definition; E8-3-12-null-to-nullable-conversion; E8-3-3-nullable-default-hasvalue; E8-3-3-nullable-default-value-throws
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int? value = new int?();
Into: int? value = new int?(7);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int? value = new int?(); int? literal = null; bool expected = false;
        try { int ignored = value.Value; }
        catch (InvalidOperationException) { expected = true; }
        catch (Exception) { }
        Check(!value.HasValue && !literal.HasValue && expected, "null-value-throws-required-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
