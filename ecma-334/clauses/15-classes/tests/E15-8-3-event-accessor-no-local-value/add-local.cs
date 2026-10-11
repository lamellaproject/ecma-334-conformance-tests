/*
Rules: E15-8-3-event-accessor-no-local-value
Authority: ECMA-334 7th ed 15.8.3
Version: 7.3
Expected: reject
Mutate: System.Action value = null;
Into: System.Action other = null;
Csc: CS0136
*/
class Source { public event System.Action Signal { add { System.Action value = null; } remove { } } }
class Program { static void Main() { } }
