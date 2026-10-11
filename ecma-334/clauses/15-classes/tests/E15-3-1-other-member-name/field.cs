/*
Rules: E15-3-1-other-member-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: public int Meter;
Into: public int Number;
*/
class Meter { public int Meter; }
class Program { static void Main() { } }
