/*
Rules: E12-16-throw-statement-semantics
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw (Exception)null
Into: throw new Exception()
*/
using System;
class Program
{
    static int Run() => throw (Exception)null;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try { int value = Run(); Check(false, "null-throw-must-fail"); }
        catch (NullReferenceException) { Check(true, "null-throw-has-statement-null-semantics"); }
        catch (Exception) { Check(false, "wrong-exception"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
