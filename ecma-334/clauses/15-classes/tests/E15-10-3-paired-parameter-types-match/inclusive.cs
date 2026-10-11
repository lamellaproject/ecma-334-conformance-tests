/*
Rules: E15-10-3-paired-parameter-types-match
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: operator <=(Gauge a, string b)
Into: operator <=(Gauge a, object b)
Csc: CS0216
*/
class Gauge { public static bool operator >=(Gauge a, object b) { return true; } public static bool operator <=(Gauge a, string b) { return false; } }
class Program { static void Main() { } }
