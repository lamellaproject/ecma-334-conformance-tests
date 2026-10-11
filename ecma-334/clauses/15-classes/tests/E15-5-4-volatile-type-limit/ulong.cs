/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile ulong Value;
Into: public ulong Value;
Csc: CS0677
*/
class Holder { public volatile ulong Value; }
class Program { static void Main() { new Holder().Value = 271UL; } }
