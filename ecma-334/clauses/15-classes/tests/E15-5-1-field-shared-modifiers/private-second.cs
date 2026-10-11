/*
Rules: E15-5-1-field-shared-modifiers
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: private int First = 71, Second = 83;
Into: public int First = 71, Second = 83;
Csc: CS0122
*/
class Holder { private int First = 71, Second = 83; }
class Program { static void Main() { int value = new Holder().Second; } }
