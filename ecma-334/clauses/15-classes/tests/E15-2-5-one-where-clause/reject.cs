/*
Rules: E15-2-5-one-where-clause
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : class where T : new()
Into: where T : class, new()
*/
class Box<T> where T : class where T : new() { }
class Program { static void Main() { } }
