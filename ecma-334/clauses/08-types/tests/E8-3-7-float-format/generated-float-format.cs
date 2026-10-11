/*
Rules: E8-3-7-float-format; E8-3-7-signed-zero-values; E8-3-7-signed-zero-usual-equivalence; E8-3-7-finite-floating-form; E8-3-7-float-finite-bounds; E8-3-7-denormalized-valid-values; E8-3-7-denormalized-support-choice; E8-3-7-float-approximate-range; E8-3-7-float-decimal-precision
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
        float zero = 0.0f; float one = 1.0f; float negativeZero = -zero;
        float max = float.MaxValue; float min = float.Epsilon; float exactDigits = 1234567.0f;
        // Denormal support is optional; either flushing to zero or the IEC encoding is permitted.
        Check(sizeof(float) == 4 && BitConverter.SingleToInt32Bits(one) == 0x3f800000, "float-iec-width-and-one");
        Check(BitConverter.SingleToInt32Bits(negativeZero) == unchecked((int)0x80000000), "float-negative-zero");
        Check(zero == negativeZero && zero + one == negativeZero + one, "float-zeros-usually-equivalent");
        Check(BitConverter.SingleToInt32Bits(max) == 0x7f7fffff, "float-maximum-finite-bound");
        Check(min == 0.0f || BitConverter.SingleToInt32Bits(min) == 1, "float-optional-denormal-minimum");
        Check((long)exactDigits == 1234567L, "float-decimal-digits-retained");
        Check(one + one / 2 == 1.5f, "float-finite-binary-scaled-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
