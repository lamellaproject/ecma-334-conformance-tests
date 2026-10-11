/*
Rules: E15-5-1-readonly-volatile-exclusive
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: public readonly volatile int Value;
Into: public volatile int Value;
Csc: CS0678
*/
class Holder { public readonly volatile int Value; }
class Program { static void Main() { int value = new Holder().Value; } }
