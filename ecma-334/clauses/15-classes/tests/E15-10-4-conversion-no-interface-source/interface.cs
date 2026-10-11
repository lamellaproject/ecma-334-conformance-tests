/*
Rules: E15-10-4-conversion-no-interface-source
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: interface Token { }
Into: class Token { }
Csc: CS0552
*/
interface Token { }
class Gauge { public static explicit operator Gauge(Token x) { return new Gauge(); } }
class Program { static void Main() { } }
