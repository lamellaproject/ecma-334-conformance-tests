/*
Rules: E22-5-5-1-caller-info-overload-resolution
Authority: ECMA-334 7th ed 22.5.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int value = Item.Choose();
Into: int value = Item.Choose("explicit");
*/
using System;
class Item
{
    public static int Choose([System.Runtime.CompilerServices.CallerMemberName] string name = null) { return 1; }
    public static int Choose() { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = Item.Choose();
        Check(value == 2, "omitted-parameter-overload-resolution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
