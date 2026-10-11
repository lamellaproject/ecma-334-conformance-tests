/*
Rules: E15-6-2-1-this-no-out
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this out int value
Into: this ref int value
Csc: CS8328
*/
static class Extensions { public static void Supply(this out int value) { value = 3; } }
class Program { static void Main() { } }
