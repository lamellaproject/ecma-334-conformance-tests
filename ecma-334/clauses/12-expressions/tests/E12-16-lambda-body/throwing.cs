/*
Rules: E12-16-lambda-body; E12-16-implicit-throw-conversion
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: () => throw saved
Into: () => false
*/
using System;
delegate bool Work();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception saved = new Exception(); Work work = () => throw saved;
        try { bool value = work(); Check(false, "lambda-must-throw"); }
        catch (Exception e) { Check(object.ReferenceEquals(e, saved), "throw-expression-is-lambda-body"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
