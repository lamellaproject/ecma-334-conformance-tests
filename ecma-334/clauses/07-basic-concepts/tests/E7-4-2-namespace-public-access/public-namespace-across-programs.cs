/*
Rules: E7-4-2-namespace-public-access; E7-5-2-namespace-default-access
Authority: ECMA-334 7th ed 7.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: namespace Branch
Into: namespace Renamed
*/
using System;
#if LIBRARY
namespace Grove
{
    namespace Branch { public class Item { public static int Read() { return 41; } } }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Grove.Branch.Item.Read() == 41, "namespace-path-accessible-in-referencing-program");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
