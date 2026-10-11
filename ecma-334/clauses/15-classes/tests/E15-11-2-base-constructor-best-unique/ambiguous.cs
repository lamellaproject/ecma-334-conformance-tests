/*
Rules: E15-11-2-base-constructor-best-unique
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : base(null)
Into: : base((Token)null)
Csc: CS0121
*/
class Token { }
class Basis { public Basis(string x) { } public Basis(Token x) { } }
class Gauge : Basis { public Gauge() : base(null) { } }
class Program { static void Main() { } }
