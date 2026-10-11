/*
Rules: E7-5-2-top-level-type-access
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: private class Item
Into: internal class Item
*/
namespace Orchard { private class Item { } }
class Program { static void Main() { } }
