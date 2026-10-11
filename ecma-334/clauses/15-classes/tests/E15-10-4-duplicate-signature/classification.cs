/*
Rules: E15-10-4-duplicate-signature; E15-10-4-conversion-signature-no-classification
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: reject
Mutate: explicit operator Gauge(int n)
Into: explicit operator Gauge(long n)
Csc: CS0557
*/
class Gauge { public static implicit operator Gauge(int n) { return new Gauge(); } public static explicit operator Gauge(int n) { return new Gauge(); } }
class Program { static void Main() { } }
