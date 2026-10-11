/*
Rules: E15-5-4-volatile-type-limit
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: reject
Mutate: public volatile long Value;
Into: public long Value;
Csc: CS0677
*/
class Holder { public volatile long Value; }
class Program { static void Main() { new Holder().Value = 269L; } }
