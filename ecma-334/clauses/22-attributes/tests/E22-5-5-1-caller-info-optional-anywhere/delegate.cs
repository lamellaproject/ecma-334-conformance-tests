/*
Rules: E22-5-5-1-caller-info-optional-anywhere
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [System.Runtime.CompilerServices.CallerMemberName] string name
Into: string name
*/
using System;
delegate string Work([System.Runtime.CompilerServices.CallerMemberName] string name = null);
class Item { public static string Echo(string name) { return name; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Work action = Item.Echo;
        Check(action() == "Main", "caller-info-on-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
