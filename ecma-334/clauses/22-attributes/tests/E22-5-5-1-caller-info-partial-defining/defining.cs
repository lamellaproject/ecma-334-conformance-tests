/*
Rules: E22-5-5-1-caller-info-partial-defining
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
partial class Item
{
    public static string Captured;
    static partial void Hit([System.Runtime.CompilerServices.CallerMemberName] string name = "default");
    static partial void Hit(string name) { Captured = name; }
    public static void Call() { Hit(); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item.Call();
        Check(Item.Captured == "Call", "defining-part-applied");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
