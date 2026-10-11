/*
Rules: E7-9-object-live-state; E7-9-object-no-longer-in-use; E7-9-object-finalization-eligibility
Authority: ECMA-334 7th ed 7.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return ref instance.Value;
Into: return ref unrelated;
*/
using System;
using System.Runtime.CompilerServices;
class Token
{
    public static int Finalizers;
    public int Value = 157;
    ~Token() { Finalizers++; }
}
class Program
{
    static int checks, failures, unrelated;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ref int Field() { Token instance = new Token(); return ref instance.Value; }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Observe(ref int value)
    {
        GC.Collect(); GC.WaitForPendingFinalizers();
        Check(Token.Finalizers == 0, "accessible-instance-field-prevents-finalization");
        Check(value == 157, "only-field-reference-preserves-storage");
        value++;
        Check(value == 158, "field-remains-writable-after-collection-request");
    }
    static void Main()
    {
        ref int retained = ref Field();
        Observe(ref retained);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
