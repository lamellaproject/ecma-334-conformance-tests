/*
Rules: E13-14-multiple-resources-nested-equivalence; E13-14-multiple-resource-declarations
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Resource first = Make(1), second = Make(2))
Into: using (Resource second = Make(2), first = Make(1))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace, disposed;
    static Exception expected = new Exception();
    class Resource : IDisposable
    {
        public void Dispose() { disposed++; trace = trace * 10 + 3; }
    }
    static Resource Make(int digit)
    {
        trace = trace * 10 + digit;
        if (digit == 2) throw expected;
        return new Resource();
    }
    static void Main()
    {
        bool body = false;
        Exception observed = null;
        try { using (Resource first = Make(1), second = Make(2)) { body = true; } }
        catch (Exception actual) { observed = actual; }
        Check(!body && observed == expected, "later-acquisition-fails-before-body");
        Check(trace == 123 && disposed == 1, "earlier-resource-disposed-after-later-acquisition-fails");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
