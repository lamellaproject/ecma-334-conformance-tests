/*
Rules: E15-8-2-field-like-not-abstract
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: reject
Mutate: public abstract event System.Action Signal;
Into: public event System.Action Signal;
Csc: CS0079
*/
abstract class Source { public abstract event System.Action Signal; public System.Action Read() { return Signal; } }
class Program { static void Main() { } }
