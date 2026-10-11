/*
Rules: E12-10-6-integer-unchecked-truncation; E12-10-6-integer-unchecked-no-report
Authority: ECMA-334 7th ed 12.10.6
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
        Check(unchecked(A(-2147483648) - A(1)) == 2147483647, "case-0");
        Check(unchecked(A(2147483647) - A(-1)) == -2147483648, "case-1");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
