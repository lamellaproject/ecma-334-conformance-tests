/*
Rules: E15-10-2-true-one-parameter
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator true(Gauge x, int n)
Into: operator true(Gauge x)
*/
class Gauge { public static bool operator true(Gauge x, int n) { return true; } public static bool operator false(Gauge x) { return false; } }
class Program { static void Main() { } }
