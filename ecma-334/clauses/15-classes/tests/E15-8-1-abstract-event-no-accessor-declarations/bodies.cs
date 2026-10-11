/*
Rules: E15-8-1-abstract-event-no-accessor-declarations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public abstract event System.Action Signal
Into: public event System.Action Signal
Csc: CS8712
*/
abstract class Source { public abstract event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
