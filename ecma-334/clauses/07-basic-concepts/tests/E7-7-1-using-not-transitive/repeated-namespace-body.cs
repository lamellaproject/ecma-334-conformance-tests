/*
Rules: E7-7-1-using-not-transitive
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: reject
Mutate: class Second
Into: using Grove; class Second
*/
namespace Grove { class Item { public static int Read() { return 227; } } }
namespace Client
{
    using Grove;
    class First { public static int Read() { return Item.Read(); } }
}
namespace Client { class Second { public static int Read() { return Item.Read(); } } }
class Program { static void Main() { Client.First.Read(); Client.Second.Read(); } }
