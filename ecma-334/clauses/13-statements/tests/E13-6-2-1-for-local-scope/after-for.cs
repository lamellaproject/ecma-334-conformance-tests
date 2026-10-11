/*
Rules: E13-6-2-1-for-local-scope
Authority: ECMA-334 7th ed 13.6.2.1
Version: 7.3
Expected: reject
Mutate: int copy = index;
Into: int copy = 3;
*/
class Program { static void Main() { for (int index = 0; index < 3; index++) { } int copy = index; } }
