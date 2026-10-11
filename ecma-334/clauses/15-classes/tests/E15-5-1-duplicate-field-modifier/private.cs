/*
Rules: E15-5-1-duplicate-field-modifier
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: private private int Value;
Into: private int Value;
Csc: CS1004
*/
class Holder { private private int Value; }
class Program { static void Main() { } }
