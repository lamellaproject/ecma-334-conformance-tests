/*
Rules: E15-8-5-concrete-derived-implements-event
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: class Derived : Source { }
Into: abstract class Derived : Source { }
Csc: CS0534
*/
abstract class Source { public abstract event System.Action Signal; }
class Derived : Source { }
class Program { static void Main() { } }
