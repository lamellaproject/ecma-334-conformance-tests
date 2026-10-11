/*
Rules: E8-2-5-string-sealed
Authority: ECMA-334 7th ed 8.2.5
Version: 7.3
Expected: reject
Mutate: class Derived : string
Into: class Derived : object
*/
class Derived : string { }
class Program { static void Main() { } }
