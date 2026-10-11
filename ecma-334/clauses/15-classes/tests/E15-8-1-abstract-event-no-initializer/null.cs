/*
Rules: E15-8-1-abstract-event-no-initializer
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public abstract event System.Action Signal = null;
Into: public abstract event System.Action Signal;
Csc: CS0074
*/
abstract class Source { public abstract event System.Action Signal = null; }
class Program { static void Main() { } }
