/*
Rules: E13-6-4-function-body-reachable
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: int Local() { }
Into: int Local() { return 6; }
*/
class Program { static void Main() { int Local() { } } }
