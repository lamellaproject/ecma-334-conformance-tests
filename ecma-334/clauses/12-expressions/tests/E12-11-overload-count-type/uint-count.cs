/*
Rules: E12-11-overload-count-type
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: reject
Mutate: operator >>(Number x, uint count)
Into: operator >>(Number x, int count)
*/
class Number { public static Number operator >>(Number x, uint count) { return x; } }
class Program { static void Main() { } }
