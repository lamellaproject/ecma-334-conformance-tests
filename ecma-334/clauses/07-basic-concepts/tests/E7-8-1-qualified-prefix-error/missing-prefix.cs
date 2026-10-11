/*
Rules: E7-8-1-qualified-prefix-error
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: Missing.Fruit value = null;
Into: Orchard.Fruit value = null;
Csc: CS0246
*/
namespace Orchard { class Fruit { } }
class Program { static void Main() { Missing.Fruit value = null; } }
