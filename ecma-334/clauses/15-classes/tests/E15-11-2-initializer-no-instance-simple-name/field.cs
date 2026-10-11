/*
Rules: E15-11-2-initializer-no-instance-simple-name; E15-11-2-initializer-no-instance-access
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: : base(N)
Into: : base(13)
Csc: CS0120
*/
class Basis { public Basis(int n) { } }
class Gauge : Basis { int N = 13; public Gauge() : base(N) { } }
class Program { static void Main() { } }
