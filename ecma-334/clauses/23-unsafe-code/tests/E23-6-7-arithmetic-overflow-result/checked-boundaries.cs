/*
Rules: E23-6-7-arithmetic-overflow-result; E23-6-7-arithmetic-overflow-no-exception
Authority: ECMA-334 7th ed 23.6.7
Version: 7.3
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/checked-boundaries-2ed46c1e4c.cs.part
Mutate: checked { long* result = pointer + offset; }
Into: checked { throw new ArgumentException(); }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        long* pointer = (long*)ulong.MaxValue;
        ulong offset = ulong.MaxValue;
        // Boundary casts exercise overflow on the configured linear-address target; mappings and results stay unrestricted.
        bool plus = false, reverse = false, minus = false;
        try { checked { long* result = pointer + offset; } plus = true; }
        catch (Exception e) { Console.WriteLine("EXCEPTION " + e.GetType().FullName); }
        try { checked { long* result = offset + pointer; } reverse = true; }
        catch (Exception e) { Console.WriteLine("EXCEPTION " + e.GetType().FullName); }
        try { checked { long* result = pointer - offset; } minus = true; }
        catch (Exception e) { Console.WriteLine("EXCEPTION " + e.GetType().FullName); }
        Check(plus, "pointer-addition-no-overflow-exception");
        Check(reverse, "reverse-pointer-addition-no-overflow-exception");
        Check(minus, "pointer-subtraction-no-overflow-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
