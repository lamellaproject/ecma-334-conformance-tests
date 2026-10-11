/*
Rules: E15-6-2-1-this-ref-in-type-limit
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this in T value
Into: this T value
Csc: CS8338
*/
static class Extensions { public static T Read<T>(this in T value) { return value; } }
class Program { static void Main() { } }
