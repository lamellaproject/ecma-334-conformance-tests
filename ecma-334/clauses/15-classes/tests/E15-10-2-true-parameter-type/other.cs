/*
Rules: E15-10-2-true-parameter-type
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: operator true(object x)
Into: operator true(Gauge x)
Csc: CS0562
*/
class Gauge { public static bool operator true(object x) { return true; } public static bool operator false(Gauge x) { return false; } }
class Program { static void Main() { } }
