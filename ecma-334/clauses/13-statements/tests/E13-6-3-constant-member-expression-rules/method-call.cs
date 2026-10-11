/*
Rules: E13-6-3-constant-member-expression-rules
Authority: ECMA-334 7th ed 13.6.3
Version: 7.3
Expected: reject
Mutate: const int item = Get();
Into: const int item = 6;
*/
class Program { static int Get() { return 6; } static void Main() { const int item = Get(); } }
