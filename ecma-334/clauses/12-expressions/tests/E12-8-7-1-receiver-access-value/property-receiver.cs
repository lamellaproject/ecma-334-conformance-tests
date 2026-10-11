/*
Rules: E12-8-7-1-receiver-access-value; E12-8-7-1-receiver-reclassification; E12-8-7-1-instance-lookup
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Owner.Current.value
Into: Owner.Other.value
*/
using System;
struct Cell { public int value; }
class Owner
{
    public static int calls;
    public static Cell Current { get { calls++; return new Cell { value = 3 }; } }
    public static Cell Other = new Cell { value = 8 };
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Owner.Current.value;
        Check(result == 3, "property-receiver-value-used-for-member-access");
        Check(Owner.calls == 1, "property-receiver-accessor-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
