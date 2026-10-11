/*
Rules: E13-11-rethrow-ignores-variable-assignment; E13-10-6-rethrow-current-exception; E13-10-6-form-throw; E13-11-catch-rethrow-permitted
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw;
Into: throw caught;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception original = new Exception();
        Exception observed = null;
        try
        {
            try { throw original; }
            catch (Exception caught) { caught = new Exception(); throw; }
        }
        catch (Exception actual) { observed = actual; }
        Check(observed == original, "bare-rethrow-keeps-original-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
