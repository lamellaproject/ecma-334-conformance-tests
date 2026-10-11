/*
Rules: E15-3-1-finalizer-category; E15-3-1-grammar-class-member-declaration-form-9
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ~Entry() { Recorded = Number; Calls++; }
Into: ~Entry() { }
*/
using System;
using System.Runtime.CompilerServices;
class Entry
{
    public static int Recorded, Calls;
    int Number = 157;
    ~Entry() { Recorded = Number; Calls++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // Keep the allocation frame out of the collecting frame so no local can retain the object.
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Allocate() { new Entry(); }
    static void Main()
    {
        Allocate();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Check(Entry.Recorded == 157, "finalizer-reads-instance-before-discard");
        Check(Entry.Calls == 1, "finalizer-action-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
