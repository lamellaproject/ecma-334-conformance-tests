/*
Rules: E13-10-6-propagation-general-catch-match; E13-11-form-general-catches; E13-11-form-general-catch; E13-11-general-catch-definition; E13-11-catch-no-specifier-type-match; E13-11-form-filter-only-catch
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: when (value == 1)
Into: when (value == 2)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Specific : Exception { }
    static int Route(int value)
    {
        try { throw new Specific(); }
        catch when (value == 1) { return 11; }
        catch { return 17; }
    }
    static void Main()
    {
        Check(Route(1) == 11, "filter-only-catch-any-type");
        Check(Route(0) == 17, "general-catch-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
