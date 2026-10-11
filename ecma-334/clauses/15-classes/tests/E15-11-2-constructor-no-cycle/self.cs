/*
Rules: E15-11-2-constructor-no-cycle
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : this()
Into: : base()
Csc: CS0516
*/
class Gauge { public Gauge() : this() { } }
class Program { static void Main() { } }
