/*
Rules: P11-static-method-runtime-dispatch; P11-static-method-constrained-access
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 3
Mutate: return T.CreateChecked(value);
Into: return T.CreateChecked(value + 1);
*/
using System;
using System.Numerics;
// Bound corpus scope: metadata static virtual generic method on INumberBase<T>.
// These fresh values observe the selected result type without a library overflow oracle.
class Program
{
    static int checks, failures;
    static void Check(bool value, string name) { checks++; if (!value) { failures++; Console.WriteLine("FAIL " + name); } }
    static T Convert<T>(int value) where T : INumberBase<T> { return T.CreateChecked(value); }
    static int Main()
    {
        Check(Convert<long>(137) == 137L, "metadata-long-result");
        Check(Convert<double>(-219) == -219.0, "metadata-double-result");
        Check(Convert<int>(0) == 0, "metadata-int-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
