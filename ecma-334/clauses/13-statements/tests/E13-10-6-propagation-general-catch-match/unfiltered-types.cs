/*
Rules: E13-10-6-propagation-general-catch-match
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: entries++; return 17;
Into: return 17;
*/
using System;
class Program
{
    static int checks, failures, entries;
    class Specific : Exception { }
    class Other : Exception { }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Route(Exception value)
    {
        try { throw value; }
        catch { entries++; return 17; }
    }
    static void Main()
    {
        Exception first = new Specific();
        Exception second = new Other();
        Check(Route(first) == 17, "general-handler-matches-specific-type");
        Check(Route(second) == 17, "general-handler-matches-other-type");
        Check(entries == 2, "both-general-handler-entries");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
