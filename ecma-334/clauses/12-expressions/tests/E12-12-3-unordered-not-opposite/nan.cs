/*
Rules: E12-12-3-unordered-not-opposite; E12-12-3-inequality-complement
Authority: ECMA-334 7th ed 12.12.3
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: (s < f) != !(s >= f)
Into: (!(s >= f)) != !(s >= f)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        float s = float.NaN, f = 4F; double d = double.NaN, g = 4D;
        Check((s < f) != !(s >= f) && (s > f) != !(s <= f), "single-unordered-strict");
        Check((s <= f) != !(s > f) && (s >= f) != !(s < f), "single-unordered-inclusive");
        Check((d < g) != !(d >= g) && (d > g) != !(d <= g), "double-unordered-strict");
        Check((d <= g) != !(d > g) && (d >= g) != !(d < g), "double-unordered-inclusive");
        Check((s != f) == !(s == f) && (f != s) == !(f == s), "single-inequality-complement");
        Check((d != g) == !(d == g) && (g != d) == !(g == d), "double-inequality-complement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
