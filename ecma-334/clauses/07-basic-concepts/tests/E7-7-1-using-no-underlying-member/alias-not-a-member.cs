/*
Rules: E7-7-1-using-no-underlying-member
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Mutate: Client.Alias.Read()
Into: Alias.Read()
*/
namespace Grove { class Item { public static int Read() { return 199; } } }
namespace Client
{
    using Alias = Grove.Item;
    class Probe { public static int Read() { return Client.Alias.Read(); } }
}
class Program { static void Main() { } }
