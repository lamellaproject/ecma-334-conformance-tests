/*
Rules: E7-7-1-extern-alias-no-underlying-member
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"alias":"Vendor","library":"Fixture"}]}}
Mutate: Client.Vendor.Grove.Item.Read()
Into: Vendor::Grove.Item.Read()
*/
#if LIBRARY
namespace Grove { public class Item { public static int Read() { return 179; } } }
#else
namespace Client
{
    extern alias Vendor;
    class Probe { public static int Read() { return Client.Vendor.Grove.Item.Read(); } }
}
class Program { static void Main() { } }
#endif
