/*
Rules: E22-5-5-4-caller-member-special-member
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
class Caller
{
    public static string Name([System.Runtime.CompilerServices.CallerMemberName] string name = null) { return name; }
}
class Item { public static string FinalizerName; ~Item() { FinalizerName = Caller.Name(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        // Invoke the finalizer body directly so this does not depend on garbage-collection timing.
        var method = typeof(Item).GetMethod("Finalize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
        method.Invoke(new Item(), new object[0]);
        Check(Item.FinalizerName != null, "finalizer-name-substituted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
