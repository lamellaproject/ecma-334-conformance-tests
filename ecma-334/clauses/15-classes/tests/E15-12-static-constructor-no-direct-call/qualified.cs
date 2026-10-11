/*
Rules: E15-12-static-constructor-no-direct-call
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: Gauge.Gauge()
Into: Gauge.Touch()
Csc: CS0117
*/
class Gauge { static Gauge() { } public static void Touch() { } }
class Program { static void Main() { Gauge.Gauge(); } }
