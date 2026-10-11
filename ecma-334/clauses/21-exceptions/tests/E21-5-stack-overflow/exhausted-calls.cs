/*
Rules: E21-5-stack-overflow
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/exhausted-calls-8226892538.cs.part
Mutate: return Descend() + 1
Into: return 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Descend() { return Descend() + 1; }
    static void Main()
    {
        bool caught = false;
        try { int result = Descend(); }
        catch (StackOverflowException) { caught = true; }
        catch (Exception) { }
        Check(caught, "exhausted-calls-stack-overflow-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
