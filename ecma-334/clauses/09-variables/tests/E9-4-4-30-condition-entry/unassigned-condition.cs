/*
Rules: E9-4-4-30-condition-entry
Authority: ECMA-334 7th ed 9.4.4.30
Version: 7.3
Expected: reject
Mutate: bool gate;
Into: bool gate = false;
Csc: CS0165
*/
class Program { static void Main() { bool gate; int value = gate ? 1 : 2; } }
