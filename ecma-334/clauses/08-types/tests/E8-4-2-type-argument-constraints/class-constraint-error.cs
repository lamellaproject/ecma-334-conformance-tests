/*
Rules: E8-4-2-type-argument-constraints; E8-4-5-constraints-checked-on-reference; E8-4-5-class-constraint-required; E8-4-5-constraint-failure-error
Authority: ECMA-334 7th ed 8.4.2
Version: 7.3
Expected: reject
Mutate: Require<int>();
Into: Require<object>();
*/
class Program { static void Require<T>() where T : class { } static void Main() { Require<int>(); } }
