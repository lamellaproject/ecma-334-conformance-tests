/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public abstract extern event
Into: public abstract event
Csc: CS0180
*/
abstract class Source { public abstract extern event System.Action Signal; }
class Program { static void Main() { } }
