/*
Rules: E12-12-9-anonymous-entry-equality
Authority: ECMA-334 7th ed 12.12.9
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: first == second
Into: first < second
*/
using System;
delegate int D();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int captured = 3; D first = () => captured, second = () => captured;
        // Either Boolean value is allowed; completion and a statically Boolean result are the only value oracle.
        bool result = first == second;
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
