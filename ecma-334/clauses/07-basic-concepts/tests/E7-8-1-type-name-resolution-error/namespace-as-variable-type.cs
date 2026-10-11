/*
Rules: E7-8-1-type-name-resolution-error
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: Orchard value = null;
Into: Orchard.Fruit value = null;
Csc: CS0118
*/
namespace Orchard { class Fruit { } }
class Program { static void Main() { Orchard value = null; } }
