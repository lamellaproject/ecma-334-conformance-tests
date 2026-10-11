/*
Rules: E15-5-1-duplicate-field-modifier
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: public new new int Value;
Into: public new int Value;
Csc: CS1004
*/
class Basis { public int Value; }
class Holder : Basis { public new new int Value; }
class Program { static void Main() { } }
