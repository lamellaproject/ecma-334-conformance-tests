/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: private virtual event
Into: public virtual event
Csc: CS0621
*/
class Source { private virtual event System.Action Signal; }
class Program { static void Main() { } }
