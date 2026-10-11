/*
Rules: E15-2-5-minimum-base-constraint; E15-2-5-compile-time-constraint-check
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Box<object,Root>
Into: Box<Leaf,Root>
*/
class Root { }
class Leaf : Root { }
class Box<S,T> where S : T { }
class Program { static void Main() { Box<object,Root> item = null; } }
