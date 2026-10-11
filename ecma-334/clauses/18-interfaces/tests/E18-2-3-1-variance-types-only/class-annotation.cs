/*
Rules: E18-2-3-1-variance-types-only
Authority: ECMA-334 7th ed 18.2.3.1
Version: 7.3
Expected: reject
Mutate: class Shelf<out T>
Into: class Shelf<T>
Csc: CS1960
*/
class Shelf<out T> { }
class Program { static void Main() { } }
