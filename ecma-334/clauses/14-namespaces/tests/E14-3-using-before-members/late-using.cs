/*
Rules: E14-3-using-before-members
Authority: ECMA-334 7th ed 14.3
Version: 7.3
Expected: reject
Mutate: class Earlier { }
Into: // No member precedes the using.
*/
namespace Harbor
{
    class Earlier { }
    using System;
    class Later { }
}
class Program
{
    static void Main() {  }
}
