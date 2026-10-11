/*
Rules: E13-6-4-function-block-scope
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: Local();
Into: ;
*/
class Program { static void Main() { { void Local() { } } Local(); } }
