/*
Rules: E13-14-using-usage-finally-disposal; E13-1-embedded-using
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Resource resource = new Resource())
Into: if (new Resource() != null)
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Resource : IDisposable
    {
        public void Dispose() { trace = trace * 10 + 2; }
    }
    static void Main()
    {
        bool caught = false;
        try
        {
            if (true) using (Resource resource = new Resource()) { trace = 1; throw new Exception(); }
        }
        catch (Exception) { caught = true; }
        Check(caught, "usage-exception-propagates");
        Check(trace == 12, "using-disposes-on-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
