/*
Rules: E13-10-6-propagation-try-order; E13-10-6-initial-throw-point; E13-10-6-propagation-handler-transfer; E13-11-enclosing-handler-search
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: catch (Specific actual)
Into: catch (Other actual)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Specific : Exception { }
    class Other : Exception { }
    static Specific expected = new Specific();
    static void Main()
    {
        int chosen = 0;
        Exception observed = null;
        try
        {
            try { throw expected; }
            catch (Specific actual) { chosen = 1; observed = actual; }
        }
        catch (Exception actual) { chosen = 2; observed = actual; }
        Check(chosen == 1 && observed == expected, "innermost-type-handler-wins");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
