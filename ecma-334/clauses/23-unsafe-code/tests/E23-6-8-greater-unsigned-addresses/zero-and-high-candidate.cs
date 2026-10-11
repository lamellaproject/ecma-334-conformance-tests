/*
Rules: E23-6-8-greater-unsigned-addresses; E23-6-8-less-unsigned-addresses; E23-6-8-greater-equal-unsigned-addresses; E23-6-8-less-equal-unsigned-addresses
Authority: ECMA-334 7th ed 23.6.8
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: bool greater = candidate > zero;
Into: bool greater = candidate < zero;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        // 23.5.1 leaves the integer mapping unconstrained: candidate may even be null.
        // 23.3 represents null by all-bits-zero, the minimum unsigned address. No pointer is dereferenced.
        byte* candidate = (byte*)ulong.MaxValue;
        byte* zero = null;
        bool same = candidate == zero;
        bool greater = candidate > zero;
        Check(greater == !same, "candidate-greater-than-zero");
        Check(!(candidate < zero), "candidate-not-less-than-zero");
        Check(candidate >= zero, "candidate-at-least-zero");
        Check((candidate <= zero) == same, "candidate-at-most-zero-only-if-equal");
        Check((zero < candidate) == !same, "zero-less-than-nonzero-candidate");
        Check(!(zero > candidate), "zero-not-greater-than-candidate");
        Check(zero <= candidate, "zero-at-most-candidate");
        Check((zero >= candidate) == same, "zero-at-least-candidate-only-if-equal");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
