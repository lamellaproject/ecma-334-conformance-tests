/*
Rules: E15-10-4-conversion-containing-endpoint
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: operator int(Token x)
Into: operator Gauge(Token x)
Csc: CS0556
*/
using System;
class Token { }
class Gauge { public static explicit operator int(Token x) { throw new Exception(); } }
class Program { static void Main() { } }
