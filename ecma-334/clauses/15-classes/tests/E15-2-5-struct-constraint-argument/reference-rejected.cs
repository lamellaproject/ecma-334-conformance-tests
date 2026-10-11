/*
Rules: E15-2-5-struct-constraint-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Box<object>
Into: Box<int>
*/
class Box<T> where T : struct { }
class Program { static void Main() { Box<object> item = null; } }
