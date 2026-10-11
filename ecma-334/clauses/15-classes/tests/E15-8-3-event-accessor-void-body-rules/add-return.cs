/*
Rules: E15-8-3-event-accessor-void-body-rules; E15-8-3-event-accessor-return-no-expression
Authority: ECMA-334 7th ed 15.8.3
Version: 7.3
Expected: reject
Mutate: return value;
Into: return;
Csc: CS0127
*/
class Source { public event System.Action Signal { add { return value; } remove { } } }
class Program { static void Main() { } }
