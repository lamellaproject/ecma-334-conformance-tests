/*
Rules: E15-8-2-field-like-no-explicit-accessors
Authority: ECMA-334 7th ed 15.8.2
Version: 7.3
Expected: reject
Mutate: public event System.Action Signal { add { } remove { } }
Into: public event System.Action Signal;
Csc: CS0079
*/
class Source { public event System.Action Signal { add { } remove { } } public System.Action Read() { return Signal; } }
class Program { static void Main() { } }
