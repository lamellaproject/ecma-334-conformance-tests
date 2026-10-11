/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile decimal Value;
Into: public decimal Value;
Csc: CS0677
*/
class Holder { public volatile decimal Value; }
class Program { static void Main() { new Holder().Value = 17.25m; } }
