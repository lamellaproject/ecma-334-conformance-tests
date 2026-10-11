/*
Rules: E12-9-3-checked-overflow; E12-9-3-unchecked-overflow
Authority: ECMA-334 7th ed 12.9.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int result = checked(-i)
Into: int result = unchecked(-i)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int i = int.MinValue; long l = long.MinValue;
        bool caughtI = false, caughtL = false;
        try { int result = checked(-i); } catch (OverflowException) { caughtI = true; } catch (Exception) { }
        try { long result = checked(-l); } catch (OverflowException) { caughtL = true; } catch (Exception) { }
        Check(caughtI, "checked-int-type"); Check(caughtL, "checked-long-type");
        Check(unchecked(-i) == i, "unchecked-int"); Check(unchecked(-l) == l, "unchecked-long");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
