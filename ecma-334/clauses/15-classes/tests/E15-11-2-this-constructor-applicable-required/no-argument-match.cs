/*
Rules: E15-11-2-this-constructor-applicable-required
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : this("coil")
Into: : this(13)
Csc: CS1503
*/
class Gauge { public Gauge() : this("coil") { } public Gauge(int n) { } }
class Program { static void Main() { } }
