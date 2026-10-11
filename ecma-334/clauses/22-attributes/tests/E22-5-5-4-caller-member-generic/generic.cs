/*
Rules: E22-5-5-4-caller-member-generic
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
class Item { public static string Make<T>() { return Caller.Name(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Item.Make<int>() == "Make", "generic-method-name-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
