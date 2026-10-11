/*
Rules: E13-11-finally-escaping-exception-replacement; E13-10-6-propagation-finally-replaces-exception; E13-11-finally-escaping-exception-propagation
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw second;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception first = new Exception();
        Exception second = new Exception();
        Exception observed = null;
        try
        {
            try { throw first; }
            finally { throw second; }
        }
        catch (Exception actual) { observed = actual; }
        Check(observed == second, "finally-exception-replaces-pending-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
