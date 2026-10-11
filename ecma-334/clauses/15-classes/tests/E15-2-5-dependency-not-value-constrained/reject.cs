/*
Rules: E15-2-5-dependency-not-value-constrained
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : struct
Into: 
*/
class Box<S,T> where S : T where T : struct { }
class Program { static void Main() { } }
