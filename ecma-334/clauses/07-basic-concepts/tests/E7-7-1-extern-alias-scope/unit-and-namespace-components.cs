/*
Rules: E7-7-1-extern-alias-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"alias":"Vendor","library":"Fixture"}]}}
Mutate: [assembly: Vendor::Grove.Mark]
Into: [assembly: Missing::Grove.Mark]
*/
#if LIBRARY
namespace Grove
{
    public class MarkAttribute : System.Attribute { }
    public class Item { public static int Read() { return 173; } }
}
#else
extern alias Vendor;
using Alias = Vendor::Grove;
using System;
[assembly: Vendor::Grove.Mark]
namespace Client
{
    extern alias Vendor;
    using Alias = Vendor::Grove;
    class Probe { public static int Read() { return Alias.Item.Read(); } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Vendor::Grove.Item.Read() == 173, "extern-alias-in-compilation-unit-member");
        Check(Alias.Item.Read() == 173, "extern-alias-in-compilation-unit-using-directive");
        Check(Client.Probe.Read() == 173, "extern-alias-in-namespace-using-and-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif
