/*
Rules: E22-5-5-4-caller-member-explicit-interface
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
interface Contract { string Name(); }
class Item : Contract { string Contract.Name() { return Caller.Name(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Contract item = new Item();
        Check(item.Name() == "Name", "explicit-interface-name-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
