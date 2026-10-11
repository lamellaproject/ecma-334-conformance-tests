/*
Rules: E9-4-4-24-creation-first-argument-entry
Authority: ECMA-334 7th ed 9.4.4.24
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 0;
Csc: CS0165
*/
class Holder { public Holder(int value) { } }
class Program { static void Main() { int cell; new Holder(cell); } }
