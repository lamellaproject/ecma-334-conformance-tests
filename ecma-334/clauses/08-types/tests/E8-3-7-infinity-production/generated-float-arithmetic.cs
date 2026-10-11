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
        float zero = 0.0f; float one = 1.0f; float max = float.MaxValue;
        float positiveInfinity = one / zero; float negativeInfinity = -one / zero; float nan = zero / zero;
        float overflow = (float)(max * 2); float tiny = 1e-30f; float huge = 1e30f;
        float underflow = (float)(tiny / huge); float edge = 16777216.0f;
        float rounded = (float)(edge + 3.0f); float assignment = one; assignment /= zero;
        float promoted = one + 3; float excess = (edge + one) - edge;
        Check(positiveInfinity == float.PositiveInfinity && negativeInfinity == float.NegativeInfinity, "float-division-infinities");
        Check(nan != nan, "float-invalid-division-nan");
        Check(overflow == positiveInfinity, "float-overflow-infinity");
        Check(underflow == 0.0f, "float-underflow-zero");
        Check(nan + one != nan + one, "float-nan-propagation-left");
        Check(one + nan != one + nan, "float-nan-propagation-right");
        Check(positiveInfinity - positiveInfinity != positiveInfinity - positiveInfinity, "float-invalid-infinity-operation");
        Check(rounded == 16777220.0f, "float-nearest-rounding");
        Check(assignment == positiveInfinity, "float-assignment-no-exception");
        Check(promoted == 4.0f, "float-binary-numeric-promotion");
        Check(excess == 0.0f || excess == 1.0f, "float-permitted-excess-precision");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
