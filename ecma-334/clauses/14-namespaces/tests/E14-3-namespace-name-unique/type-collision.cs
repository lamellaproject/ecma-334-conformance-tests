/*
Rules: E14-3-namespace-name-unique
Authority: ECMA-334 7th ed 14.3
Version: 7.3
Expected: reject
Mutate: namespace Harbor { }
Into: namespace Canal { }
*/
class Harbor { }
namespace Harbor { }
class Program
{
    static void Main() {  }
}
