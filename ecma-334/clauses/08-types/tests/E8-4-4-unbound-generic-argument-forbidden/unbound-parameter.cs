/*
Rules: E8-4-4-unbound-generic-argument-forbidden; E8-4-4-unbound-generic-not-type; E8-4-1-unbound-generic-typeof-only; E8-4-4-unbound-generic-only-typeof
Authority: ECMA-334 7th ed 8.4.4
Version: 7.3
Expected: reject
Mutate: Template<> value
Into: Template<int> value
*/
class Template<T> { }
class Program { static void Accept(Template<> value) { } static void Main() {  } }
