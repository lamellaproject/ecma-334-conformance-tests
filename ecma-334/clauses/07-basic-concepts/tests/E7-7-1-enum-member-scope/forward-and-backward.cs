/*
Rules: E7-7-1-enum-member-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Third = 83
Into: Renamed = 83
*/
using System;
enum Item { First = Third, Second = First + 1, Third = 83 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Item.First == 83, "forward-unqualified-enum-member");
        Check((int)Item.Second == 84, "backward-unqualified-enum-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
