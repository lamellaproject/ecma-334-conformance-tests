/*
Rules: E15-8-5-event-accessor-method-semantics
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: public new event System.Action Signal;
Into: public new virtual event System.Action Signal;
Csc: CS0506
*/
class Source { public virtual event System.Action Signal; }
class Middle : Source { public new event System.Action Signal; }
class Derived : Middle { public override event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
