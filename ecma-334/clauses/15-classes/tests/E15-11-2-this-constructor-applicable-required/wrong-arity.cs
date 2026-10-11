/*
Rules: E15-11-2-this-constructor-applicable-required
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : this(13)
Into: : base()
Csc: CS1729
*/
class Gauge { public Gauge() : this(13) { } }
class Program { static void Main() { } }
