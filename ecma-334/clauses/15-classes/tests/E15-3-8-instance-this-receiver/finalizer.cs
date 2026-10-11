/*
Rules: E15-3-8-instance-this-receiver; E15-3-8-instance-classification
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ~Receipt()
Into: void Dispose()
*/
using System;
using System.Runtime.CompilerServices;
class Receipt
{
    public static int Finalized;
    private int value;
    public Receipt(int value) { this.value = value; }
    ~Receipt() { Finalized = this.value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Release() { new Receipt(229); }
    static void Main()
    {
        Release();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Receipt.Finalized == 229, "finalizer-this-identifies-finalized-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
