/*
Rules: E15-6-9-partial-type-required
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: class Gauge
Into: partial class Gauge
Csc: CS0751
*/
class Gauge { partial void Record(); }
class Program { static void Main() { } }
