/*
Rules: E15-2-5-class-constraint-not-object
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : object
Into: where T : class
*/
class Box<T> where T : object { }
class Program { static void Main() { } }
