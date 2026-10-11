/*
Rules: E15-8-5-override-event-name
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: public override event System.Action Other
Into: public override event System.Action Signal
Csc: CS0115
*/
class Source { public virtual event System.Action Signal; }
class Derived : Source { public override event System.Action Other { add { } remove { } } }
class Program { static void Main() { } }
