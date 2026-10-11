/*
Rules: E13-6-4-used-variable-before-function
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: int Local() => state;
Into: int Local() => 6;
*/
class Program { static void Main() { int Local() => state; int state = 6; } }
