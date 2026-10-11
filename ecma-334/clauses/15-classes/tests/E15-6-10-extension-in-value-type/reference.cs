/*
Rules: E15-6-10-extension-in-value-type
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: this in object receiver
Into: this object receiver
Csc: CS8338
*/
static class Extensions { public static object Read(this in object receiver) { return receiver; } }
class Program { static void Main() { } }
