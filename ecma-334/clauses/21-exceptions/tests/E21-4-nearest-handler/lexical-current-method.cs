/*
Rules: E21-4-nearest-handler; E21-4-current-method-search; E21-4-try-handling
Authority: ECMA-334 7th ed 21.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: catch (Exception) { inner = true; }
Into: catch (InvalidOperationException) { inner = true; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool inner = false, outer = false;
        try
        {
            try { throw new Exception(); }
            catch (Exception) { inner = true; }
        }
        catch (Exception) { outer = true; }
        Check(inner, "nearest-current-method-handler");
        Check(!outer, "outer-handler-not-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
