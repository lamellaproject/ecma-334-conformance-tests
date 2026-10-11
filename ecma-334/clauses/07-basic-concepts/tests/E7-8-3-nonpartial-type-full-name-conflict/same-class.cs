/*
Rules: E7-8-3-nonpartial-type-full-name-conflict; E7-8-3-fully-qualified-name-uniqueness
Authority: ECMA-334 7th ed 7.8.3
Version: 7.3
Expected: reject
Mutate: namespace Orchard { class Item { } }
Into: namespace Orchard { partial class Item { } }
Csc: CS0260
*/
namespace Orchard { class Item { } }
namespace Orchard { partial class Item { } }
class Program { static void Main() { } }
