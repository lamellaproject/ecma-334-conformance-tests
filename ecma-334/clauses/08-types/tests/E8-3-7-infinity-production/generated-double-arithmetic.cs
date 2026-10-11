/*
Rules: E8-3-7-infinity-production; E8-3-7-infinity-values; E8-3-7-nan-value; E8-3-7-nan-invalid-operation; E8-3-7-floating-binary-promotion; E8-3-7-floating-binary-precision; E8-3-7-floating-no-exceptions; E8-3-7-floating-exceptional-results; E8-3-7-floating-nearest-rounding; E8-3-7-floating-underflow-zero; E8-3-7-floating-overflow-infinity; E8-3-7-floating-invalid-nan; E8-3-7-floating-nan-propagation; E8-3-7-floating-excess-precision
Authority: ECMA-334 7th ed 8.3.7
Version: 7.3
Expected: run
Stdout: OK 11
Generated: clauses/08-types/generators/floating-matrix.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double zero = 0.0d; double one = 1.0d; double max = double.MaxValue;
        double positiveInfinity = one / zero; double negativeInfinity = -one / zero; double nan = zero / zero;
        double overflow = (double)(max * 2); double tiny = 1e-300d; double huge = 1e300d;
        double underflow = (double)(tiny / huge); double edge = 9007199254740992.0d;
        double rounded = (double)(edge + 3.0d); double assignment = one; assignment /= zero;
        double promoted = one + 3; double excess = (edge + one) - edge;
        Check(positiveInfinity == double.PositiveInfinity && negativeInfinity == double.NegativeInfinity, "double-division-infinities");
        Check(nan != nan, "double-invalid-division-nan");
        Check(overflow == positiveInfinity, "double-overflow-infinity");
        Check(underflow == 0.0d, "double-underflow-zero");
        Check(nan + one != nan + one, "double-nan-propagation-left");
        Check(one + nan != one + nan, "double-nan-propagation-right");
        Check(positiveInfinity - positiveInfinity != positiveInfinity - positiveInfinity, "double-invalid-infinity-operation");
        Check(rounded == 9007199254740996.0d, "double-nearest-rounding");
        Check(assignment == positiveInfinity, "double-assignment-no-exception");
        Check(promoted == 4.0d, "double-binary-numeric-promotion");
        Check(excess == 0.0d || excess == 1.0d, "double-permitted-excess-precision");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
