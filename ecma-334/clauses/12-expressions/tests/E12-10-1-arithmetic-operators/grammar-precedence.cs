/*
Rules: E12-10-1-arithmetic-operators; E12-10-1-form-unary; E12-10-1-form-multiply; E12-10-1-form-divide; E12-10-1-form-remainder; E12-10-1-form-multiplicative; E12-10-1-form-add; E12-10-1-form-subtract
Authority: ECMA-334 7th ed 12.10.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: a + b * c - d / e % f
Into: (a + b) * c - d / e % f
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int a = 11, b = 4, c = 6, d = 29, e = 3, f = 5;
        Check(a + b * c - d / e % f == 31, "precedence");
        Check(d / e / c == 1, "division-left-grouping");
        Check(a - b - c == 1, "subtraction-left-grouping");
        Check(-b * c == -24, "unary-before-multiply");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
