/*
Rules: E15-8-5-override-event-accessibility-modifiers
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: protected override event
Into: protected internal override event
Csc: CS0507
*/
class Source { protected internal virtual event System.Action Signal; }
class Derived : Source { protected override event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
