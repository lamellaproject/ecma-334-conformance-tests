/*
Rules: E22-5-5-4-caller-member-property-accessor
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
class Item
{
    public string SetName;
    public string Value { get { return Caller.Name(); } set { SetName = Caller.Name(); } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = new Item();
        string get = item.Value;
        item.Value = "supplied";
        Check(get == "Value", "getter-property-name");
        Check(item.SetName == "Value", "setter-property-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
