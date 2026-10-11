/*
Rules: E12-4-3-fixed-syntax
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: reject
Mutate: operator *(Box x)
Into: operator *(Box x, Box y)
*/
struct Box { public static Box operator *(Box x) { return x; } }
class Program { static void Main() { } }
