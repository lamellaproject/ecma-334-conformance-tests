/*
Rules: E12-10-3-integer-unchecked-minimum
Authority: ECMA-334 7th ed 12.10.3
Version: 7.3
Expected: run
Stdout: OK 1
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int A(int value) { return value; }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        bool c0 = false; try { int r = unchecked(A(-2147483648) / A(-1)); c0 = r == -2147483648; } catch (ArithmeticException) { c0 = true; } catch (Exception) { } Check(c0, "case-0");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
