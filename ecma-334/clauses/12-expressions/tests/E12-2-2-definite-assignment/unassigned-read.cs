/*
Rules: E12-2-2-definite-assignment
Authority: ECMA-334 7th ed 12.2.2
Version: 7.3
Expected: reject
Mutate: int value;
Into: int value = 7;
*/
class Program { static void Main() { int value; int copy = value; } }
