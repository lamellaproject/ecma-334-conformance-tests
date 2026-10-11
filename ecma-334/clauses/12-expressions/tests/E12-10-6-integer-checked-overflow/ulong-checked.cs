/*
Rules: E12-10-6-integer-checked-overflow
Authority: ECMA-334 7th ed 12.10.6
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
    static ulong A(ulong value) { return value; }
    static int Kind(ulong value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        bool c0 = false; try { ulong r = checked(A(0UL) - A(1UL)); } catch (OverflowException) { c0 = true; } catch (Exception) { } Check(c0, "case-0");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
