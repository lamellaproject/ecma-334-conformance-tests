/*
Rules: E15-5-1-field-shared-modifiers
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: public readonly int First = 97, Second = 101;
Into: public int First = 97, Second = 101;
Csc: CS0191
*/
class Holder { public readonly int First = 97, Second = 101; }
class Program { static void Main() { new Holder().First = 103; } }
