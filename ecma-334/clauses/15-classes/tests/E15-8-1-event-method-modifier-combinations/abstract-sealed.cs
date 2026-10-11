/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public abstract sealed override event
Into: public abstract override event
Csc: CS0502
*/
class Source { public virtual event System.Action Signal; }
abstract class Derived : Source { public abstract sealed override event System.Action Signal; }
class Program { static void Main() { } }
