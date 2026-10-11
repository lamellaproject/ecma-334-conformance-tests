/*
Rules: E7-8-1-namespace-name-no-type-arguments
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: using Orchard<int>;
Into: using Orchard;
*/
using Orchard<int>;
namespace Orchard { class Fruit { } }
class Program { static void Main() { } }
