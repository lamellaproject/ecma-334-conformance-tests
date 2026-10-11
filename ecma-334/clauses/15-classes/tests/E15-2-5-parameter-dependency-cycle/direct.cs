/*
Rules: E15-2-5-parameter-dependency-cycle
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : T
Into: 
*/
class Box<T> where T : T { }
class Program { static void Main() { } }
