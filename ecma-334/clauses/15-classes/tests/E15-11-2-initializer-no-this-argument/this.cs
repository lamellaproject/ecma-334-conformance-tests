/*
Rules: E15-11-2-initializer-no-this-argument; E15-11-2-initializer-no-instance-access
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : base(this)
Into: : base(null)
Csc: CS0027
*/
class Basis { public Basis(object x) { } }
class Gauge : Basis { public Gauge() : base(this) { } }
class Program { static void Main() { } }
