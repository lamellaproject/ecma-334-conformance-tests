/*
Rules: E8-4-4-unbound-generic-base-forbidden; E8-4-4-unbound-generic-not-type; E8-4-1-unbound-generic-typeof-only; E8-4-4-unbound-generic-only-typeof
Authority: ECMA-334 7th ed 8.4.4
Version: 7.3
Expected: reject
Mutate: class Derived : Template<>
Into: class Derived : Template<int>
*/
class Template<T> { }
class Derived : Template<> { }
class Program { static void Main() {  } }
