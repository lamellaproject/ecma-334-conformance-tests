/*
Rules: E7-3-local-space-name-sources; E7-3-statement-local-spaces
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: catch (Exception caught)
Into: catch (Exception renamed)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var sentinel = new Exception();
        try { throw sentinel; }
        catch (Exception caught) { Check(ReferenceEquals(caught, sentinel), "exception-specifier-name-introduced"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
