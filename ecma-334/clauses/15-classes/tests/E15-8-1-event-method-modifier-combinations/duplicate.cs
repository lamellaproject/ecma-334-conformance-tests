/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public public event
Into: public event
Csc: CS1004
*/
class Source { public public event System.Action Signal; }
class Program { static void Main() { } }
