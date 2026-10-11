/*
Rules: E7-3-member-containing-type-name
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: reject
Mutate: public int Holder;
Into: public int Value;
*/
class Holder { public int Holder; }
class Program { static void Main() { } }
