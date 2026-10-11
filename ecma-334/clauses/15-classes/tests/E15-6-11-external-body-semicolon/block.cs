/*
Rules: E15-6-11-external-body-semicolon
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: { return 29; }
Into: ;
*/
class Box { public static extern int Read() { return 29; } }
class Program { static void Main() { } }
