/*
Rules: E15-2-2-4-1-static-protected-member
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: protected static int Reading;
Into: private static int Reading;
*/
static class Gauge { protected static int Reading; }
class Program { static void Main() { } }
