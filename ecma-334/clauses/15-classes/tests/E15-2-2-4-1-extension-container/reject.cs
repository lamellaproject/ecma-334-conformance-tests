/*
Rules: E15-2-2-4-1-extension-container
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: class Gauge
Into: static class Gauge
*/
class Gauge { public static int Read(this int value) { return value; } }
class Program { static void Main() { } }
