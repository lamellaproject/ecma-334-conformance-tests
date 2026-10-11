/*
Rules: E15-2-5-parameter-dependency-cycle
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where U : S
Into: 
*/
class Box<S,T,U> where S : T where T : U where U : S { }
class Program { static void Main() { } }
