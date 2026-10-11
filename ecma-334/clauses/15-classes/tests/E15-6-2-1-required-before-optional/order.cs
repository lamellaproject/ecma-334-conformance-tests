/*
Rules: E15-6-2-1-required-before-optional
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: int first = 3, int second
Into: int first, int second
Csc: CS1737
*/
class Holder { public int Combine(int first = 3, int second) { return first + second; } }
class Program { static void Main() { } }
