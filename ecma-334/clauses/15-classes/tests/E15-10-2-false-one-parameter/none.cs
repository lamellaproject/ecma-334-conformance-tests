/*
Rules: E15-10-2-false-one-parameter
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator false()
Into: operator false(Gauge x)
*/
class Gauge { public static bool operator false() { return true; } public static bool operator true(Gauge x) { return false; } }
class Program { static void Main() { } }
