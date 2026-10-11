/*
Rules: E7-7-1-using-no-underlying-member
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Mutate: Client.Item.Read()
Into: Item.Read()
*/
namespace Grove { class Item { public static int Read() { return 211; } } }
namespace Client
{
    using Grove;
    class Probe { public static int Read() { return Client.Item.Read(); } }
}
class Program { static void Main() { } }
