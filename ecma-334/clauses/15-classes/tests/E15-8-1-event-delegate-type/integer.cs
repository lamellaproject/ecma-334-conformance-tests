/*
Rules: E15-8-1-event-delegate-type
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: event int Signal;
Into: event System.Action Signal;
Csc: CS0066
*/
class Source { public event int Signal; }
class Program { static void Main() { } }
