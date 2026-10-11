/*
Rules: E21-5-out-of-memory
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new byte[requested]
Into: new byte[-requested]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int requested = int.MaxValue; bool allowed = false;
        // Capacity varies by implementation: a successful allocation is allowed;
        // if the attempt fails for memory capacity, its exception type is checked.
        try { byte[] block = new byte[requested]; allowed = block.Length == requested; }
        catch (OutOfMemoryException) { allowed = true; }
        catch (Exception) { }
        Check(allowed, "allocation-success-or-out-of-memory-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
