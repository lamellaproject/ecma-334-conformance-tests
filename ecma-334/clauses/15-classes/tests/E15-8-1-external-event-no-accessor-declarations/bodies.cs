/*
Rules: E15-8-1-external-event-no-accessor-declarations
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public extern event System.Action Signal
Into: public event System.Action Signal
Csc: CS0179
*/
class Source { public extern event System.Action Signal { add { } remove { } } }
class Program { static void Main() { } }
