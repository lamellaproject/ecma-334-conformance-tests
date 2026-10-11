/*
Rules: E7-5-2-enum-member-public
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: Selected = 151
Into: private Selected = 151
*/
using System;
#if LIBRARY
public enum Item { Selected = 151 }
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)Item.Selected == 151, "implicit-public-enum-member-across-programs");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
