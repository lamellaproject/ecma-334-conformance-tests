/*
Rules: E15-6-2-1-this-first-parameter
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: int first, this int second
Into: int first, int second
Csc: CS1100
*/
static class Extensions { public static int Combine(int first, this int second) { return first + second; } }
class Program { static void Main() { } }
