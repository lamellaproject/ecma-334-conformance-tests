/*
Rules: E12-4-3-overloadable-only
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: reject
Mutate: operator &&
Into: operator &
*/
struct Box { public static Box operator &&(Box x, Box y) { return x; } }
class Program { static void Main() { } }
