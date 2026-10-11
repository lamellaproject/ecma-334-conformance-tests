/*
Rules: E15-2-5-value-reference-limited-arguments
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Box<int,Root>
Into: Box<int,object>
*/
class Root { }
class Box<S,T> where S : struct, T where T : class { }
class Program { static void Main() { Box<int,Root> item = null; } }
