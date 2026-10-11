/*
Rules: P09-native-identity; P09-native-compound-identity
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 2
Mutate: IntPtr underlying=value;
Into: IntPtr underlying=default(IntPtr);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        nint value=(nint)231; IntPtr underlying=value; nint restored=underlying;
        nuint unsigned=(nuint)313; UIntPtr raw=unsigned; nuint back=raw;
        nint[] array=new nint[]{value}; IntPtr[] same=array;
        nint? maybe=value; IntPtr? wrapped=maybe;
        System.Collections.Generic.List<nint> a=new System.Collections.Generic.List<nint>{value};
        System.Collections.Generic.List<IntPtr> b=a;
        (nint, nuint) tuple=(value,unsigned); (IntPtr, UIntPtr) other=tuple;
        Check(restored==231 && back==313 && ReferenceEquals(array,same), "P09-native-identity-pilot-200001-check-01");
        Check(wrapped.Value==underlying && ReferenceEquals(a,b) && other.Item1==underlying && other.Item2==raw, "P09-native-identity-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
