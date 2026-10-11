/*
Rules: E8-3-2-derive-value-type-forbidden; E8-3-2-value-types-sealed
Authority: ECMA-334 7th ed 8.3.2
Version: 7.3
Expected: reject
Mutate: class Derived : Sample
Into: class Derived : object
*/
struct Sample { }
class Derived : Sample { }
class Program { static void Main() { } }
