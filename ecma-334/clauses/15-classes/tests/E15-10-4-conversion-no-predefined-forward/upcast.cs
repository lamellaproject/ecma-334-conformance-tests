/*
Rules: E15-10-4-conversion-no-predefined-forward; E15-10-4-conversion-no-predefined-reverse; E15-10-4-conversion-no-base-endpoints
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: class Gauge : Basis
Into: class Gauge
Csc: CS0553
*/
class Basis { }
class Gauge : Basis { public static explicit operator Basis(Gauge x) { return new Basis(); } }
class Program { static void Main() { } }
