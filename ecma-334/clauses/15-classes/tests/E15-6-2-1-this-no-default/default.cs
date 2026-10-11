/*
Rules: E15-6-2-1-this-no-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this int value = 13
Into: this int value
Csc: CS1743
*/
static class Extensions { public static int Read(this int value = 13) { return value; } }
class Program { static void Main() { } }
