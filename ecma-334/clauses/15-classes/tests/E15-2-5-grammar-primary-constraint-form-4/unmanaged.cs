/*
Rules: E15-2-5-grammar-primary-constraint-form-4; E15-2-5-unmanaged-constraint-fallback
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : unmanaged
Into: where T : struct
*/
using System;
class Program
{
    static unsafe int RawSize<U>() where U : unmanaged { return sizeof(U); }
    static int Size<T>() where T : unmanaged { return RawSize<T>(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Size<int>() == 4, "unresolved-unmanaged-is-constraint-int");
        Check(Size<short>() == 2, "unresolved-unmanaged-is-constraint-short");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
