/*
Rules: E7-8-1-namespace-name-resolution-error
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: using Orchard.Fruit;
Into: using Orchard;
Csc: CS0138
*/
using Orchard.Fruit;
namespace Orchard { class Fruit { } }
class Program { static void Main() { } }
