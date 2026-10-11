/*
Rules: E7-3-enum-space; E7-3-enum-member-names; E7-3-enum-declaration-order; E7-3-type-declaration-categories
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: enum Later { First = 7, Second, Third }
Into: enum Later { First = 8, Second, Third }
*/
using System;
enum Earlier { First, Second }
enum Later { First = 7, Second, Third }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Earlier.First == 0 && (int)Earlier.Second == 1, "enum-own-space-default-order");
        Check((int)Later.First == 7 && (int)Later.Second == 8, "same-names-other-enum");
        Check((int)Later.Third == 9, "omitted-value-successor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
