/*
Rules: E7-8-1-type-alias-conflict
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: using Fruit = Other;
Into: using Route = Other;
Csc: CS0576
*/
class Other { }
namespace Orchard
{
    using Fruit = Other;
    class Fruit { }
    class Reader { public Fruit value; }
}
class Program { static void Main() { } }
