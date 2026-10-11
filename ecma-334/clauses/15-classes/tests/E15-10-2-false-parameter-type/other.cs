/*
Rules: E15-10-2-false-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator false(object x)
Into: operator false(Gauge x)
Csc: CS0562
*/
class Gauge { public static bool operator false(object x) { return true; } public static bool operator true(Gauge x) { return false; } }
class Program { static void Main() { } }
