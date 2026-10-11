/*
Rules: E13-6-4-no-enclosing-local-name
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: int token = 7;
Into: int other = 7;
*/
class Program { static void Main() { int token = 6; void Local() { int token = 7; } } }
