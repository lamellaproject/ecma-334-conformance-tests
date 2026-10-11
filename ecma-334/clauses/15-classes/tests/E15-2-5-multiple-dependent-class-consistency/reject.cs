/*
Rules: E15-2-5-multiple-dependent-class-consistency
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: class Right
Into: class Right : Left
*/
class Left { }
class Right { }
class Box<S,T,U> where S : T, U where T : Left where U : Right { }
class Program { static void Main() { } }
