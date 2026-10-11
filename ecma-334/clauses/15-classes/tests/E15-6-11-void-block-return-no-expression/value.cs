/*
Rules: E15-6-11-void-block-return-no-expression
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: return 5;
Into: return;
*/
class Program { static void Work() { return 5; } static void Main() { } }
