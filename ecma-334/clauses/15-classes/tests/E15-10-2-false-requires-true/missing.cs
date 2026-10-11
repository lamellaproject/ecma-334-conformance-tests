/*
Rules: E15-10-2-false-requires-true
Authority: ECMA-334 7th ed 15.10.2
Version: 7.3
Expected: reject
Mutate: public static bool operator false(Gauge x) { return true; }
Into: public static bool operator false(Gauge x) { return true; } public static bool operator true(Gauge x) { return false; }
Csc: CS0216
*/
class Gauge { public static bool operator false(Gauge x) { return true; } }
class Program { static void Main() { } }
