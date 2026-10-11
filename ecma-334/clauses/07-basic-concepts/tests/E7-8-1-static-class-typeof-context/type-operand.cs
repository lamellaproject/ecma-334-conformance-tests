/*
Rules: E7-8-1-static-class-typeof-context
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Type observed = typeof(Tools);
Into: Type observed = typeof(Other);
*/
using System;
static class Tools { }
static class Other { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type observed = typeof(Tools);
        Check(observed == typeof(Tools) && observed != typeof(Other), "static-class-typeof-denotes-selected-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
