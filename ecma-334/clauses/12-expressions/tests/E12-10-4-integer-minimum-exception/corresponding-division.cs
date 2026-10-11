/*
Rules: E12-10-4-integer-minimum-exception
Authority: ECMA-334 7th ed 12.10.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: r = checked(x % y);
Into: r = checked(x % 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int x = int.MinValue, y = -1; long a = long.MinValue, b = -1;
        bool div = false, rem = false, other = false; int r = 99;
        try { int q = checked(x / y); } catch (ArithmeticException) { div = true; } catch (Exception) { other = true; }
        try { r = checked(x % y); } catch (OverflowException) { rem = true; } catch (Exception) { other = true; }
        Check(!other && div == rem && (rem || r == 0), "checked-int-iff-division");
        div = rem = other = false; r = 99;
        try { int q = unchecked(x / y); } catch (ArithmeticException) { div = true; } catch (Exception) { other = true; }
        try { r = unchecked(x % y); } catch (OverflowException) { rem = true; } catch (Exception) { other = true; }
        Check(!other && div == rem && (rem || r == 0), "unchecked-int-iff-division");
        div = rem = other = false; long lr = 99;
        try { long q = checked(a / b); } catch (ArithmeticException) { div = true; } catch (Exception) { other = true; }
        try { lr = checked(a % b); } catch (OverflowException) { rem = true; } catch (Exception) { other = true; }
        Check(!other && div == rem && (rem || lr == 0), "checked-long-iff-division");
        div = rem = other = false; lr = 99;
        try { long q = unchecked(a / b); } catch (ArithmeticException) { div = true; } catch (Exception) { other = true; }
        try { lr = unchecked(a % b); } catch (OverflowException) { rem = true; } catch (Exception) { other = true; }
        Check(!other && div == rem && (rem || lr == 0), "unchecked-long-iff-division");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
