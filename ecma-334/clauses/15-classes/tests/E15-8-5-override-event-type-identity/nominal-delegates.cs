/*
Rules: E15-8-5-override-event-type-identity
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: public override event Second Signal
Into: public override event First Signal
Csc: CS1715
*/
delegate void First();
delegate void Second();
class Source { public virtual event First Signal; }
class Derived : Source { public override event Second Signal { add { } remove { } } }
class Program { static void Main() { } }
