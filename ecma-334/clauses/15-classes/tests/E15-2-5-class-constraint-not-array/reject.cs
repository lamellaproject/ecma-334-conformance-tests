/*
Rules: E15-2-5-class-constraint-not-array
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : System.Array
Into: where T : class
*/
class Box<T> where T : System.Array { }
class Program { static void Main() { } }
