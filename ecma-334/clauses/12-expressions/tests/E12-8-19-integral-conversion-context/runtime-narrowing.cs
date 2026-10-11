/*
Rules: E12-8-19-integral-conversion-context; E12-8-19-checked-range; E12-8-19-unchecked-truncation
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: ushort result = checked((ushort)wide);
Into: ushort result = unchecked((ushort)wide);
*/
using System;
enum Tiny : byte { Zero }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int wide = int.MaxValue, enumSource = 257;
        bool integralOverflow = false, enumOverflow = false;
        try { ushort result = checked((ushort)wide); }
        catch (OverflowException) { integralOverflow = true; }
        catch (Exception) { }
        try { Tiny result = checked((Tiny)enumSource); }
        catch (OverflowException) { enumOverflow = true; }
        catch (Exception) { }
        Check(integralOverflow, "checked-integral-narrowing");
        Check(enumOverflow, "checked-enum-narrowing");
        Check(unchecked((ushort)wide) == 65535, "unchecked-integral-low-word");
        Check(unchecked((Tiny)enumSource) == (Tiny)1, "unchecked-enum-low-byte");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
