/*
Rules: E15-5-1-duplicate-field-modifier
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: internal internal int Value;
Into: internal int Value;
Csc: CS1004
*/
class Holder { internal internal int Value; }
class Program { static void Main() { } }
