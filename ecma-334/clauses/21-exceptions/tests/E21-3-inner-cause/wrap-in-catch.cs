/*
Rules: E21-3-inner-cause; E21-3-inner-type; E21-3-inner-catch-context; E21-3-constructor-inner
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Exception("operation failed", caught)
Into: new Exception("operation failed")
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception original = new Exception("invalid input");
        Exception wrapper = null;
        try
        {
            try { throw original; }
            catch (Exception caught) { throw new Exception("operation failed", caught); }
        }
        catch (Exception caught) { wrapper = caught; }
        Exception inner = wrapper.InnerException;
        Check(inner == original, "cause-is-handled-original");
        Check(wrapper.Message == "operation failed" && inner.Message == "invalid input", "wrapper-and-cause-descriptions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
