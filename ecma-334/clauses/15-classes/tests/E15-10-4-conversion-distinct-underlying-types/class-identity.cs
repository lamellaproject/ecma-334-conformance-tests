/*
Rules: E15-10-4-conversion-distinct-underlying-types
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: operator Gauge(Gauge x)
Into: operator Token(Gauge x)
Csc: CS0555
*/
using System;
class Token { }
class Gauge { public static explicit operator Gauge(Gauge x) { throw new Exception(); } }
class Program { static void Main() { } }
