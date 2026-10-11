/*
Rules: E15-2-5-class-constraint-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Box<int>
Into: Box<object>
*/
class Box<T> where T : class { }
class Program { static void Main() { Box<int> item = null; } }
