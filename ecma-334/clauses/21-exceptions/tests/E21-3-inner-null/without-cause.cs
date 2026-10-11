/*
Rules: E21-3-inner-null
Authority: ECMA-334 7th ed 21.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Exception("direct failure")
Into: new Exception("direct failure", new Exception("cause"))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception direct = new Exception("direct failure");
        Check(direct.InnerException == null, "constructed-without-cause");
        try { throw direct; }
        catch (Exception caught) { Check(caught.InnerException == null, "throw-does-not-create-cause"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
