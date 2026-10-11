/*
Rules: E15-2-2-4-1-static-protected-internal-member
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: protected internal static int Reading;
Into: internal static int Reading;
*/
static class Gauge { protected internal static int Reading; }
class Program { static void Main() { } }
