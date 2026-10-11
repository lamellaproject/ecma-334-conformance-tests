/*
Rules: E12-14-3-true-required; E12-14-3-false-required
Authority: ECMA-334 7th ed 12.14.3
Version: 7.3
Expected: reject
Mutate: x && y
Into: x & y
*/
// Operator declarations are paired, so absence of both is the otherwise-valid witness.
class Flag { public static Flag operator &(Flag x, Flag y) { return x; } }
class Program { static void Main() { Flag x = new Flag(), y = new Flag(); var result = x && y; } }
