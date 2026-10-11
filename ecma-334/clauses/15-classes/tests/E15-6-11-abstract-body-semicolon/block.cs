/*
Rules: E15-6-11-abstract-body-semicolon
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: { return 17; }
Into: ;
*/
abstract class Box { public abstract int Read() { return 17; } }
class Program { static void Main() { } }
