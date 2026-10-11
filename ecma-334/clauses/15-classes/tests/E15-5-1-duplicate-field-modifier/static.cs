/*
Rules: E15-5-1-duplicate-field-modifier
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: public static static int Value;
Into: public static int Value;
Csc: CS1004
*/
class Holder { public static static int Value; }
class Program { static void Main() { } }
