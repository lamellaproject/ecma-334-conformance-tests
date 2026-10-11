/*
Rules: E15-8-3-event-accessor-no-constant-value
Authority: ECMA-334 7th ed 15.8.3
Version: 7.3
Expected: reject
Mutate: const int value = 4;
Into: const int other = 4;
Csc: CS0136
*/
class Source { public event System.Action Signal { add { } remove { const int value = 4; } } }
class Program { static void Main() { } }
