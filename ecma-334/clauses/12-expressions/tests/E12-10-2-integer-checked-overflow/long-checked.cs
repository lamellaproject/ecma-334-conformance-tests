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
    static long A(long value) { return value; }
    static int Kind(long value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        bool c0 = false; try { long r = checked(A(9223372036854775807L) * A(2L)); } catch (OverflowException) { c0 = true; } catch (Exception) { } Check(c0, "case-0");
        bool c1 = false; try { long r = checked(A(-9223372036854775808L) * A(-1L)); } catch (OverflowException) { c1 = true; } catch (Exception) { } Check(c1, "case-1");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
