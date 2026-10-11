/*
Rules: E15-2-2-4-1-static-base-specification
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/class-7ff82eeebd.cs.part
Mutate: static class Gauge : object
Into: static class Gauge
*/
static class Gauge : object { }
class Program { static void Main() { } }
