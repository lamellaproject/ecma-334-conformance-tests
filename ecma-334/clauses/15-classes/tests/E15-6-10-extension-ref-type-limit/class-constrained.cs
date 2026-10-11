/*
Rules: E15-6-10-extension-ref-type-limit
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: where T : class
Into: where T : struct
Csc: CS8337
*/
static class Extensions { public static T Read<T>(this ref T receiver) where T : class { return receiver; } }
class Program { static void Main() { } }
