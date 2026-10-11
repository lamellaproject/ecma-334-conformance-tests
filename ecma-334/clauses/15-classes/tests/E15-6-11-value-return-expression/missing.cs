/*
Rules: E15-6-11-value-return-expression
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: return;
Into: return 16;
*/
class Program { static int Read() { return; } static void Main() { } }
