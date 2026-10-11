/*
Rules: E7-8-1-namespace-alias-conflict
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: using Grove = Other;
Into: using Route = Other;
Csc: CS0576
*/
namespace Other { class Fruit { } }
namespace Orchard
{
    using Grove = Other;
    namespace Grove { class Fruit { } }
    class Reader { public Grove.Fruit value; }
}
class Program { static void Main() { } }
