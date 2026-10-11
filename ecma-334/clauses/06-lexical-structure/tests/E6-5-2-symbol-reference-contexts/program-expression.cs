/*
Rules: E6-5-2-symbol-reference-contexts
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: reject
Mutate: = ONLY_DIRECTIVE;
Into: = true;
*/
#define ONLY_DIRECTIVE
class Program { static void Main() { bool amount = ONLY_DIRECTIVE; } }
