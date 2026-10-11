/*
Rules: E7-7-1-using-scope; E7-7-1-using-import-names
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: [assembly: Mark]
Into: [assembly: Missing]
*/
using System;
using Grove;
using Empty;
using BranchAlias = Grove.Branch;
using TypeAlias = Grove.Item;
[assembly: Mark]
namespace Empty { }
namespace Grove
{
    public class MarkAttribute : Attribute { }
    class Item { public static int Read() { return 193; } }
    namespace Branch { class Item { public static int Read() { return 197; } } }
}
namespace Client
{
    using Grove;
    class Probe { public static int Read() { return Item.Read(); } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Item.Read() == 193 && TypeAlias.Read() == 193, "type-import-and-type-alias-in-unit-member");
        Check(BranchAlias.Item.Read() == 197, "namespace-alias-in-unit-member");
        Check(Client.Probe.Read() == 193, "type-import-in-namespace-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
