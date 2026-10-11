/*
Rules: E15-2-5-partial-constrained-parameter-set
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where U : class
Into: where T : class
*/
partial class Box<T,U> where T : class { }
partial class Box<T,U> where U : class { }
class Program { static void Main() { } }
