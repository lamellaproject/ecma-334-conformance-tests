/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile double Value;
Into: public double Value;
Csc: CS0677
*/
class Holder { public volatile double Value; }
class Program { static void Main() { new Holder().Value = 0.125d; } }
