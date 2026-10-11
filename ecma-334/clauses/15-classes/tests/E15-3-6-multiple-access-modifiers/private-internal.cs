/*
Rules: E15-3-6-multiple-access-modifiers
Authority: ECMA-334 7th ed 15.3.6
Version: 7.3
Expected: reject
Mutate: private internal int Number;
Into: internal int Number;
*/
class Meter { private internal int Number; }
class Program { static void Main() { } }
