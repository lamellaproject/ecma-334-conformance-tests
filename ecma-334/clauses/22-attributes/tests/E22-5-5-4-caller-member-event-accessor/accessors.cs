/*
Rules: E22-5-5-4-caller-member-event-accessor
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
class Caller
{
    public static string Name([System.Runtime.CompilerServices.CallerMemberName] string name = null) { return name; }
}
delegate void Signal();
class Item
{
    public string AddName, RemoveName;
    public event Signal Changed { add { AddName = Caller.Name(); } remove { RemoveName = Caller.Name(); } }
}
class Sink { public static void Hit() { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        Signal handler = Sink.Hit;
        item.Changed += handler;
        item.Changed -= handler;
        Check(item.AddName == "Changed", "add-event-name");
        Check(item.RemoveName == "Changed", "remove-event-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
