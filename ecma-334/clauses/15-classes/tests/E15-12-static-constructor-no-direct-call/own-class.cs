/*
Rules: E15-12-static-constructor-no-direct-call
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: public static void Invoke() { Gauge(); }
Into: public static void Invoke() { Touch(); }
*/
class Gauge { static Gauge() { } public static void Touch() { } public static void Invoke() { Gauge(); } }
class Program { static void Main() { } }
