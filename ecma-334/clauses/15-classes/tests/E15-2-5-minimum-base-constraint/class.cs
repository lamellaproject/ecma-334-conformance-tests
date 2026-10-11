/*
Rules: E15-2-5-minimum-base-constraint; E15-2-5-compile-time-constraint-check
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Box<object>
Into: Box<Root>
*/
class Root { }
class Box<T> where T : Root { }
class Program { static void Main() { Box<object> item = null; } }
