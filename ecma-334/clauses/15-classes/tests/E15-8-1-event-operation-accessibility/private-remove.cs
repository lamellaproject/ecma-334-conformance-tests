/*
Rules: E15-8-1-event-operation-accessibility
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: private event System.Action Signal;
Into: public event System.Action Signal;
Csc: CS0122
*/
class Source { private event System.Action Signal; }
class Program { static void Main() { new Source().Signal -= () => { }; } }
