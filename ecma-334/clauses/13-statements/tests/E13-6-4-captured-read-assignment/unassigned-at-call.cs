/*
Rules: E13-6-4-captured-read-assignment
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: int state;
Into: int state = 6;
*/
class Program { static void Main() { int state; int Local() => state; int result = Local(); } }
