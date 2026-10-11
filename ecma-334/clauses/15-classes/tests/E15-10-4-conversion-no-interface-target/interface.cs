/*
Rules: E15-10-4-conversion-no-interface-target
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: interface Token { }
Into: class Token { }
Csc: CS0552
*/
interface Token { }
class Gauge { public static explicit operator Token(Gauge x) { return null; } }
class Program { static void Main() { } }
