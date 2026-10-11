/*
Rules: E15-3-6-multiple-access-modifiers
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: reject
Mutate: public private int Number;
Into: public int Number;
*/
class Meter { public private int Number; }
class Program { static void Main() { } }
