/*
Rules: E8-2-2-predefined-exception-base
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: throw new InvalidOperationException();
Into: throw new ArgumentException();
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool matched = false;
        try { throw new InvalidOperationException(); }
        catch (InvalidOperationException) { matched = true; }
        catch (Exception) { }
        Check(matched, "predefined-exception-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
