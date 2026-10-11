/*
Rules: E15-2-2-4-1-static-members-only; E15-2-2-4-1-static-explicit-member-modifier
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: public int Reading;
Into: public static int Reading;
*/
static class Gauge { public int Reading; }
class Program { static void Main() { } }
