/*
Rules: E13-6-2-1-local-duplicate-function
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: void token() { }
Into: void other() { }
*/
class Program { static void Main() { int token = 6; void token() { } } }
