/*
Rules: E13-6-2-1-ordinary-local-scope; E13-3-1-local-variable-scope; E13-6-1-declaration-space
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int copy = local;
Into: int copy = 6;
*/
class Program { static void Main() { { int local = 6; } int copy = local; } }
