/*
Rules: E15-6-2-1-this-static-class
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this int value
Into: int value
Csc: CS1106
*/
class Extensions { public static int Read(this int value) { return value; } }
class Program { static void Main() { } }
