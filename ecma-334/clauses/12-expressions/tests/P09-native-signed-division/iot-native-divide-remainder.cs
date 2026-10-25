/*
Rules: P09-native-signed-division; P09-native-unsigned-division; P09-native-signed-remainder; P09-native-unsigned-remainder
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 10
Mutate: left / right
Into: unchecked((nint)((nuint)left / (nuint)right))
*/
using System;
class Program
{
    static int checks, failures;
    static nint Divide(nint left, nint right) { return left / right; }
    static nuint DivideUnsigned(nuint a, nuint b) { return a / b; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        nint negative = -91, positive = 91, divisor = 8;
        Check(Divide(negative, divisor) == -11, "signed-quotient-toward-zero");
        Check(negative % divisor == -3, "negative-dividend-remainder");
        Check(Divide(positive, -divisor) == -11, "negative-divisor-quotient");
        Check(positive % -divisor == 3, "positive-dividend-remainder");
        nuint zero = 0, high = ~zero;
        Check(DivideUnsigned(high, 2) == (high >> 1), "unsigned-high-bit-quotient");
        Check(high % 2 == 1, "unsigned-high-bit-remainder");
        bool signedZero = false, unsignedZero = false, signedRemZero = false, unsignedRemZero = false;
        try { nint result = Divide(positive, 0); }
        catch (DivideByZeroException) { signedZero = true; }
        try { nuint result = DivideUnsigned(high, zero); }
        catch (DivideByZeroException) { unsignedZero = true; }
        try { nint result = positive % (nint)zero; }
        catch (DivideByZeroException) { signedRemZero = true; }
        try { nuint result = high % zero; }
        catch (DivideByZeroException) { unsignedRemZero = true; }
        Check(signedZero, "signed-division-zero");
        Check(unsignedZero, "unsigned-division-zero");
        Check(signedRemZero, "signed-remainder-zero");
        Check(unsignedRemZero, "unsigned-remainder-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
