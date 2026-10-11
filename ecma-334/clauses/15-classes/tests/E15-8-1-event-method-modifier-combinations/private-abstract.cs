/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: private abstract event
Into: public abstract event
Csc: CS0621
*/
abstract class Source { private abstract event System.Action Signal; }
class Program { static void Main() { } }
