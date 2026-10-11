/*
Rules: E15-6-9-partial-implementation-needs-definition
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record() { }
Into: void Record() { }
Csc: CS0759
*/
partial class Gauge { partial void Record() { } }
class Program { static void Main() { } }
