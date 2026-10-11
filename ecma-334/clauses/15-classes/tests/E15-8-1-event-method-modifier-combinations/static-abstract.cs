/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public static abstract event
Into: public abstract event
Csc: CS0112
*/
abstract class Source { public static abstract event System.Action Signal; }
class Program { static void Main() { } }
