/*
Rules: E13-6-3-constant-scope; E13-3-1-local-constant-scope
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: reject
Mutate: int copy = token;
Into: int copy = 6;
*/
class Program { static void Main() { { const int token = 6; } int copy = token; } }
