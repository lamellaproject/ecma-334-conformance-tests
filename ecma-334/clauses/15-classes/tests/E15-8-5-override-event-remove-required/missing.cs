/*
Rules: E15-8-5-override-event-remove-required
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: { add { } }
Into: { add { } remove { } }
Csc: CS0065
*/
class Source { public virtual event System.Action Signal; }
class Derived : Source { public override event System.Action Signal { add { } } }
class Program { static void Main() { } }
