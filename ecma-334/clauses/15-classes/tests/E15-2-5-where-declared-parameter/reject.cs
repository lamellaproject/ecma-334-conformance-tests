/*
Rules: E15-2-5-where-declared-parameter
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where U : class
Into: where T : class
*/
class Box<T> where U : class { }
class Program { static void Main() { } }
