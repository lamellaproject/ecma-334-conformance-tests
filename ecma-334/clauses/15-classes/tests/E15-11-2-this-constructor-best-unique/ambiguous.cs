/*
Rules: E15-11-2-this-constructor-best-unique
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : this(null)
Into: : this((Token)null)
Csc: CS0121
*/
class Token { }
class Gauge { public Gauge() : this(null) { } private Gauge(string x) { } private Gauge(Token x) { } }
class Program { static void Main() { } }
