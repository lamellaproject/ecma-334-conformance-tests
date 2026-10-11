/*
Rules: E15-2-2-4-1-static-explicit-member-modifier; E15-2-2-4-1-static-members-only
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: reject
Mutate: public int Read()
Into: public static int Read()
*/
static class Gauge { public int Read() { return 139; } }
class Program { static void Main() { } }
