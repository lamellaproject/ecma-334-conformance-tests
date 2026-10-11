/*
Rules: E15-8-5-override-event-no-new
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: public new override event
Into: public override event
Csc: CS0113
*/
class Source { public virtual event System.Action Signal; }
class Derived : Source { public new override event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
