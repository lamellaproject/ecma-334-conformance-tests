/*
Rules: E15-2-2-4-2-static-other-contexts
Authority: ECMA-334 7th ed 15.2.2.4.2
Version: 7.3
Expected: reject
Mutate: object value = Gauge;
Into: object value = null;
*/
static class Gauge { }
class Program { static void Main() { object value = Gauge; } }
