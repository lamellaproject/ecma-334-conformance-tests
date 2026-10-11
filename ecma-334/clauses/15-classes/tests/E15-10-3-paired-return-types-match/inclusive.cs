/*
Rules: E15-10-3-paired-return-types-match
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: reject
Mutate: long operator <=
Into: int operator <=
Csc: CS0216
*/
class Gauge { public static int operator >=(Gauge a, Gauge b) { return 1; } public static long operator <=(Gauge a, Gauge b) { return 2; } }
class Program { static void Main() { } }
