/*
Rules: E12-14-1-no-direct-overload
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: reject
Mutate: operator &&
Into: operator &
*/
class Flag { public static Flag operator &&(Flag x, Flag y) { return x; } }
class Program { static void Main() { } }
