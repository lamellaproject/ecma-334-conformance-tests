/*
Rules: E8-3-8-decimal-overflow
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: maximum + 1m
Into: maximum / 1m
*/
using System;
// 8.3.8, p. 79: this test uses decimal precision, as corrected in types.md,
// 8.3.8 at dotnet/csharpstandard commit 6460eafbf957c24565c0ba099f6077e8c701e3c9.
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        decimal maximum = decimal.MaxValue; bool correct = false;
        try { decimal value = maximum + 1m; }
        catch (OverflowException) { correct = true; }
        catch (Exception) { }
        Check(correct, "decimal-magnitude-overflow-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
