/*
Rules: E15-2-5-duplicate-parameter-constraint
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where S : T, T
Into: where S : T
*/
class Box<S,T> where S : T, T { }
class Program { static void Main() { } }
