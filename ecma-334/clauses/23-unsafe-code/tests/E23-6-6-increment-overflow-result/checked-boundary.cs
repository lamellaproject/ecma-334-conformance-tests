/*
Rules: E23-6-6-increment-overflow-result; E23-6-6-increment-overflow-no-exception
Authority: ECMA-334 7th ed 23.6.6
Version: 7.3
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/checked-boundary-781c149414.cs.part
Mutate: checked { pointer++; }
Into: checked { throw new ArgumentException(); }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        byte* pointer = (byte*)ulong.MaxValue;
        // The integer mapping and resulting pointer are unrestricted; boundary inputs wrap on the configured target.
        bool completed = false;
        try { checked { pointer++; } completed = true; }
        catch (Exception e) { Console.WriteLine("EXCEPTION " + e.GetType().FullName); }
        Check(completed, "checked-pointer-increment-completes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
