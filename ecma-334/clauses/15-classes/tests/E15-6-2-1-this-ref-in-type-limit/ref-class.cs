/*
Rules: E15-6-2-1-this-ref-in-type-limit
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this ref Holder value
Into: this Holder value
Csc: CS8337
*/
class Holder { }
static class Extensions { public static Holder Read(this ref Holder value) { return value; } }
class Program { static void Main() { } }
