/*
Rules: E15-8-5-sealed-event-no-further-override; E15-8-5-sealed-event-accessors
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: public sealed override event System.Action Signal;
Into: public override event System.Action Signal;
Csc: CS0239
*/
class Source { public virtual event System.Action Signal; }
class Middle : Source { public sealed override event System.Action Signal; }
class Derived : Middle { public override event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
