/*
Rules: E15-8-4-static-event-no-this
Authority: ECMA-334 7th ed 15.8.4
Version: 7.3
Expected: reject
Mutate: public static event System.Action Signal
Into: public event System.Action Signal
Csc: CS0026
*/
class Source { int trace; public static event System.Action Signal { add { } remove { this.trace++; } } }
class Program { static void Main() { } }
