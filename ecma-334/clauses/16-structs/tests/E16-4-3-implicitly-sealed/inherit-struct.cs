/*
Rules: E16-4-3-implicitly-sealed
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: struct Parent
Into: class Parent
*/
struct Parent { }
class Child : Parent { }
class Program { static void Main() { } }
