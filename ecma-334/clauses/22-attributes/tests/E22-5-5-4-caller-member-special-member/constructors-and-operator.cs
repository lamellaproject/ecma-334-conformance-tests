/*
Rules: E22-5-5-4-caller-member-special-member
Authority: ECMA-334 7th ed 22.5.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
class Caller
{
    public static string Name([System.Runtime.CompilerServices.CallerMemberName] string name = null) { return name; }
}
class Item
{
    public static string StaticName, OperatorName;
    public string InstanceName;
    static Item() { StaticName = Caller.Name(); }
    public Item() { InstanceName = Caller.Name(); }
    public static Item operator +(Item a, Item b) { OperatorName = Caller.Name(); return a; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        Item sum = item + item;
        // Special-member names are implementation-dependent; every string spelling is allowed.
        Check(Item.StaticName != null, "static-constructor-name-substituted");
        Check(item.InstanceName != null, "instance-constructor-name-substituted");
        Check(Item.OperatorName != null, "operator-name-substituted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
