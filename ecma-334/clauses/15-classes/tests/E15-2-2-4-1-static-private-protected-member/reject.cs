/*
Rules: E15-2-2-4-1-static-private-protected-member
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: private protected static int Reading;
Into: private static int Reading;
*/
static class Gauge { private protected static int Reading; }
class Program { static void Main() { } }
