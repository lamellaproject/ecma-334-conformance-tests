/*
Rules: E14-3-namespace-no-access-modifier
Authority: ECMA-334 7th ed 14.3
Version: 7.3
Expected: reject
Mutate: internal namespace Harbor
Into: namespace Harbor
*/
internal namespace Harbor { }
class Program
{
    static void Main() {  }
}
