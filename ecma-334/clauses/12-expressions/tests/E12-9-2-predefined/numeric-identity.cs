/*
Rules: E12-9-2-predefined; E12-9-2-identity; E12-9-1-form-primary; E12-9-1-form-plus
Authority: ECMA-334 7th ed 12.9.2
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: +(I(7))
Into: -(I(7))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int I(int x) { return x; }
    static uint U(uint x) { return x; }
    static long L(long x) { return x; }
    static ulong UL(ulong x) { return x; }
    static float F(float x) { return x; }
    static double D(double x) { return x; }
    static decimal M(decimal x) { return x; }
    static void Main()
    {
        int i = +(I(7)); uint u = +U(8); long l = +L(9); ulong ul = +UL(10);
        float f = +F(1.5f); double d = +D(-2.25); decimal m = +M(3.125m);
        Check(i == 7, "int"); Check(u == 8, "uint"); Check(l == 9, "long"); Check(ul == 10, "ulong");
        Check(f == 1.5f, "float"); Check(d == -2.25, "double"); Check(m == 3.125m, "decimal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
