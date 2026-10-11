/*
Rules: E12-6-2-1-no-output-reference
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: reject
Mutate: this[ref int number]
Into: this[in int number]
*/
class Box { public int this[ref int number] { get { return number; } } }
class Program { static void Main() { } }
