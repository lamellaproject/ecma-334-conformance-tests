/*
Rules: E15-6-11-void-expression-statement
Authority: ECMA-334 7th ed 15.6.11
Version: 7.3
Expected: reject
Mutate: void Work() => 12;
Into: void Work() => Other();
*/
class Program { static void Other() { } static void Work() => 12; static void Main() { } }
