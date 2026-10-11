/*
Rules: E12-8-19-floating-conversion-context; E12-8-19-checked-range
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: checked((sbyte)wide)
Into: unchecked((sbyte)wide)
*/
using System;
enum Small : byte { Zero }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double wide = 128.75, inside = 126.75;
        float enumSource = 256.5f;
        bool floatingOverflow = false, enumOverflow = false;
        try { sbyte result = checked((sbyte)wide); }
        catch (OverflowException) { floatingOverflow = true; }
        catch (Exception) { }
        try { Small result = checked((Small)enumSource); }
        catch (OverflowException) { enumOverflow = true; }
        catch (Exception) { }
        Check(floatingOverflow, "checked-floating-narrowing");
        Check(enumOverflow, "checked-floating-enum-narrowing");
        Check(checked((sbyte)inside) == 126, "checked-floating-in-range-truncation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
