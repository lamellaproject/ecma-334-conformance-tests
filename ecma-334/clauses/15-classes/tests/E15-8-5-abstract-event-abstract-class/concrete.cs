/*
Rules: E15-8-5-abstract-event-abstract-class
Authority: ECMA-334 7th ed 15.8.5
Version: 7.3
Expected: reject
Mutate: class Source
Into: abstract class Source
Csc: CS0513
*/
class Source { public abstract event System.Action Signal; }
class Program { static void Main() { } }
