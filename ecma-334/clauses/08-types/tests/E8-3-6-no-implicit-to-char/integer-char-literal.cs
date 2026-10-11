/*
Rules: E8-3-6-no-implicit-to-char; E8-3-6-char-constant-spelling-restriction
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: reject
Mutate: const char value = 81;
Into: const char value = (char)81;
*/
class Program { static void Main() { const char value = 81; } }
