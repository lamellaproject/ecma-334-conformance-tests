/*
Rules: E15-13-no-explicit-finalize-override
Authority: ECMA-334 7th ed 15.13
Version: 7.3
Expected: reject
Mutate: protected override void Finalize()
Into: ~Gauge()
*/
class Gauge { protected override void Finalize() { } }
class Program { static void Main() { } }
