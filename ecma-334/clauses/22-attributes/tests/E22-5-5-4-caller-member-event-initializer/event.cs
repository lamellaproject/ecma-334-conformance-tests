/*
Rules: E22-5-5-4-caller-member-event-initializer
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
delegate void Signal();
class Capture
{
    public static string Name;
    public static Signal Create([System.Runtime.CompilerServices.CallerMemberName] string name = null) { Name = name; return null; }
}
class Item { public event Signal Changed = Capture.Create(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        Check(Capture.Name == "Changed", "event-initializer-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
