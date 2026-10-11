/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public sealed event
Into: public sealed override event
Csc: CS0238
*/
class Source { public virtual event System.Action Signal; }
class Derived : Source { public sealed event System.Action Signal; }
class Program { static void Main() { } }
