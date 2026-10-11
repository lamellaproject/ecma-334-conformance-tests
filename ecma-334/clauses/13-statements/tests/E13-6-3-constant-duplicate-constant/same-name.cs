/*
Rules: E13-6-3-constant-duplicate-constant
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: reject
Mutate: const int token = 7;
Into: const int other = 7;
*/
class Program { static void Main() { const int token = 6; const int token = 7; } }
