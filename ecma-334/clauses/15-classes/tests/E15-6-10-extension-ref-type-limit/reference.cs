/*
Rules: E15-6-10-extension-ref-type-limit
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: this ref object receiver
Into: this object receiver
Csc: CS8337
*/
static class Extensions { public static object Read(this ref object receiver) { return receiver; } }
class Program { static void Main() { } }
