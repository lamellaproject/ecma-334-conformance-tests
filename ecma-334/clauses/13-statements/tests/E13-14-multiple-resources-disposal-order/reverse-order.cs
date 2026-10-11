/*
Rules: E13-14-multiple-resources-disposal-order; E13-14-multiple-resources-acquisition-order; E13-14-multiple-resource-declarations; E13-14-multiple-resources-nested-equivalence
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using (Resource first = new Resource(1), second = new Resource(2))
Into: using (Resource second = new Resource(2), first = new Resource(1))
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Resource : IDisposable
    {
        int digit;
        public Resource(int id) { digit = id; trace = trace * 10 + id; }
        public void Dispose() { trace = trace * 10 + digit; }
    }
    static void Main()
    {
        using (Resource first = new Resource(1), second = new Resource(2)) { trace = trace * 10 + 3; }
        Check(trace == 12321, "acquire-forward-dispose-reverse");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
