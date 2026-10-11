/*
Rules: E13-6-4-no-enclosing-type-parameter-name
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: void Local<token>()
Into: void Local<Other>()
*/
class Program { static void Main() { int token = 6; void Local<token>() { } } }
