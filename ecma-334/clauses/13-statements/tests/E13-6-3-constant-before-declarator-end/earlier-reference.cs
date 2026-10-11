/*
Rules: E13-6-3-constant-before-declarator-end
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: reject
Mutate: int copy = token;
Into: int copy = 6;
*/
class Program { static void Main() { int copy = token; const int token = 6; } }
