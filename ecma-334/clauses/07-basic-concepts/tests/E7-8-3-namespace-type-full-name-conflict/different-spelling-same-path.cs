/*
Rules: E7-8-3-namespace-type-full-name-conflict; E7-8-3-fully-qualified-name-uniqueness
Authority: ECMA-334 7th ed 7.8.3
Version: 7.3
Expected: reject
Mutate: namespace Orchard { class Grove { } }
Into: namespace Orchard { class Other { } }
Csc: CS0101
*/
namespace Orchard.Grove { }
namespace Orchard { class Grove { } }
class Program { static void Main() { } }
