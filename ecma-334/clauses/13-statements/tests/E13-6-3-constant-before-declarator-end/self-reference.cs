/*
Rules: E13-6-3-constant-before-declarator-end
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: reject
Mutate: const int token = token;
Into: const int token = 6;
*/
class Program { static void Main() { const int token = token; } }
