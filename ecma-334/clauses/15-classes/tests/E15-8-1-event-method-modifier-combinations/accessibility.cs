/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public private event
Into: public event
Csc: CS0107
*/
class Source { public private event System.Action Signal; }
class Program { static void Main() { } }
