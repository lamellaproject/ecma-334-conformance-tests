/*
Rules: E8-3-7-double-format; E8-3-7-signed-zero-values; E8-3-7-signed-zero-usual-equivalence; E8-3-7-finite-floating-form; E8-3-7-double-finite-bounds; E8-3-7-denormalized-valid-values; E8-3-7-denormalized-support-choice; E8-3-7-double-approximate-range; E8-3-7-double-decimal-precision
Authority: ECMA-334 7th ed 8.3.7
Version: 7.3
Expected: run
Stdout: OK 7
Generated: clauses/08-types/generators/floating-matrix.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        double zero = 0.0d; double one = 1.0d; double negativeZero = -zero;
        double max = double.MaxValue; double min = double.Epsilon; double exactDigits = 123456789012345.0d;
        // Denormal support is optional; either flushing to zero or the IEC encoding is permitted.
        Check(sizeof(double) == 8 && BitConverter.DoubleToInt64Bits(one) == 0x3ff0000000000000L, "double-iec-width-and-one");
        Check(BitConverter.DoubleToInt64Bits(negativeZero) == unchecked((long)0x8000000000000000UL), "double-negative-zero");
        Check(zero == negativeZero && zero + one == negativeZero + one, "double-zeros-usually-equivalent");
        Check(BitConverter.DoubleToInt64Bits(max) == 0x7fefffffffffffffL, "double-maximum-finite-bound");
        Check(min == 0.0d || BitConverter.DoubleToInt64Bits(min) == 1, "double-optional-denormal-minimum");
        Check((long)exactDigits == 123456789012345L, "double-decimal-digits-retained");
        Check(one + one / 2 == 1.5d, "double-finite-binary-scaled-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
