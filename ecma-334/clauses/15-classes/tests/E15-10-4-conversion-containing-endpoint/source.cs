/*
Rules: E15-10-4-conversion-containing-endpoint
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: operator Token(int n)
Into: operator Token(Gauge n)
Csc: CS0556
*/
class Token { }
class Gauge { public static explicit operator Token(int n) { return new Token(); } }
class Program { static void Main() { } }
