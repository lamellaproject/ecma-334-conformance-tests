/*
Rules: E15-8-5-abstract-override-event-accessors; E15-8-5-concrete-derived-implements-event
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: class Derived : Middle { }
Into: abstract class Derived : Middle { }
Csc: CS0534
*/
class Source { public virtual event System.Action Signal; }
abstract class Middle : Source { public abstract override event System.Action Signal; }
class Derived : Middle { }
class Program { static void Main() { } }
