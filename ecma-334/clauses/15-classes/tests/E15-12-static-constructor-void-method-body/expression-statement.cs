/*
Rules: E15-12-static-constructor-void-method-body
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: reject
Mutate: => 13;
Into: => N = 13;
Csc: CS0201
*/
class Gauge { public static int N; static Gauge() => 13; }
class Program { static void Main() { } }
