/*
Rules: E15-6-9-partial-no-out
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record(out int value);
Into: partial void Record(ref int value);
Csc: CS8797
*/
partial class Gauge { partial void Record(out int value); }
class Program { static void Main() { } }
