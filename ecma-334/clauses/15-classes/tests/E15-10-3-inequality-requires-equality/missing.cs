/*
Rules: E15-10-3-inequality-requires-equality
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: public static bool operator !=(Gauge a, Gauge b) { return true; }
Into: public static bool operator !=(Gauge a, Gauge b) { return true; } public static bool operator ==(Gauge a, Gauge b) { return false; }
Csc: CS0216
*/
class Gauge { public static bool operator !=(Gauge a, Gauge b) { return true; } }
class Program { static void Main() { } }
