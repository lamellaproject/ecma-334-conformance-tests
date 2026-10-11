/*
Rules: E12-9-6-return-conversion-required
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: reject
Mutate: Derived value = new Derived()
Into: Base value = new Derived()
*/
class Base { public static Base operator ++(Base x) { return x; } }
class Derived : Base { }
class Program { static void Main() { Derived value = new Derived(); var result = ++value; } }
