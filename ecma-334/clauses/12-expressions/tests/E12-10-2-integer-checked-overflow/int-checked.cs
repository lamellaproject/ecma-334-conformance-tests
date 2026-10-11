/*
Rules: E12-10-2-integer-checked-overflow
Authority: ECMA-334 7th ed 12.10.2
Version: 7.3
Expected: run
Stdout: OK 2
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
        bool c0 = false; try { int r = checked(A(2147483647) * A(2)); } catch (OverflowException) { c0 = true; } catch (Exception) { } Check(c0, "case-0");
        bool c1 = false; try { int r = checked(A(-2147483648) * A(-1)); } catch (OverflowException) { c1 = true; } catch (Exception) { } Check(c1, "case-1");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
