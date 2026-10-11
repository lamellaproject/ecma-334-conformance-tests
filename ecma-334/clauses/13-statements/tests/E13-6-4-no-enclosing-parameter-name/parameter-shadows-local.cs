/*
Rules: E13-6-4-no-enclosing-parameter-name
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: void Local(int token)
Into: void Local(int other)
*/
class Program { static void Main() { int token = 6; void Local(int token) { } } }
