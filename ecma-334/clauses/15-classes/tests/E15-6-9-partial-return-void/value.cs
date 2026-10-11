/*
Rules: E15-6-9-partial-return-void
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial int Record();
Into: partial void Record();
*/
partial class Gauge { partial int Record(); }
class Program { static void Main() { } }
