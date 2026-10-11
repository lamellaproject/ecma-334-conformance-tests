/*
Rules: E15-8-5-event-accessor-method-semantics
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: public event System.Action Signal;
Into: public virtual event System.Action Signal;
Csc: CS0506
*/
class Source { public event System.Action Signal; }
class Derived : Source { public override event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
