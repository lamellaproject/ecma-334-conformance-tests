/*
Rules: E15-8-1-external-event-no-initializer
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public extern event System.Action Signal = null;
Into: public extern event System.Action Signal;
Csc: CS8760
*/
class Source { public extern event System.Action Signal = null; }
class Program { static void Main() { } }
