/*
Rules: E15-2-5-value-dependency-no-class-constraint
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : Root
Into: where T : class
*/
class Root { }
class Box<S,T> where S : struct, T where T : Root { }
class Program { static void Main() { } }
