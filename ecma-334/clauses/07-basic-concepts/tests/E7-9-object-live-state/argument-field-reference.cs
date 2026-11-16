/*
Rules: E7-9-object-live-state; E7-9-object-no-longer-in-use; E7-9-object-finalization-eligibility
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Inspect(ref Create().Value);
Into: Inspect(ref unrelated);
*/
using System;
using System.Runtime.CompilerServices;
class Cell
{
    public static int Finalizers;
    public int Value = 211;
    ~Cell() { Finalizers++; }
}
class Program
{
    static int checks, failures, unrelated;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Cell Create() { return new Cell(); }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Inspect(ref int retained)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Cell.Finalizers == 0, "field-argument-prevents-owner-finalization");
        Check(retained == 211, "field-argument-retains-storage");
        retained += 7;
        Check(retained == 218, "field-argument-remains-writable");
    }
    static void Main()
    {
        Inspect(ref Create().Value);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
