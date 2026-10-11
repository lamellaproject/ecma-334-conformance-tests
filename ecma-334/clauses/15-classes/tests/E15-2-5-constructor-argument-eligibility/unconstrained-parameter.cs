/*
Rules: E15-2-5-constructor-argument-eligibility
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: class Outer<T>
Into: class Outer<T> where T : new()
*/
class Box<T> where T : new() { }
class Outer<T> { Box<T> item; }
class Program { static void Main() { } }
