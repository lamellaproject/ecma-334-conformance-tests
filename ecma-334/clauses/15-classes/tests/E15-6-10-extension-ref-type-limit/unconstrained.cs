/*
Rules: E15-6-10-extension-ref-type-limit
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: public static T Read<T>(this ref T receiver)
Into: public static T Read<T>(this ref T receiver) where T : struct
Csc: CS8337
*/
static class Extensions { public static T Read<T>(this ref T receiver) { return receiver; } }
class Program { static void Main() { } }
