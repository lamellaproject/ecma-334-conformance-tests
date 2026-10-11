/*
Rules: E20-2-no-derivation; E20-2-implicitly-sealed
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: class Derived : Notice
Into: class Derived
Csc: CS0509
*/
delegate void Notice();
class Derived : Notice { }
class Program { static void Main() { } }
