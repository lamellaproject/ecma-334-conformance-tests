/*
Rules: E15-8-1-event-method-modifier-combinations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public static virtual event
Into: public virtual event
Csc: CS0112
*/
class Source { public static virtual event System.Action Signal; }
class Program { static void Main() { } }
