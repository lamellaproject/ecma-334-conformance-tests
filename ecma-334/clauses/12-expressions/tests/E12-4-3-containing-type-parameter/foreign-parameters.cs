/*
Rules: E12-4-3-containing-type-parameter
Authority: ECMA-334 7th ed 12.4.3
Version: 7.3
Expected: reject
Mutate: operator +(Other x, Other y)
Into: operator +(Box x, Other y)
*/
struct Other { }
struct Box { public static int operator +(Other x, Other y) { return 5; } }
class Program { static void Main() { } }
