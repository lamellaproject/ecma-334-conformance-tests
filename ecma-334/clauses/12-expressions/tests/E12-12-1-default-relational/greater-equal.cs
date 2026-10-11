/*
Rules: E12-12-1-default-relational
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: reject
Mutate: value >= default
Into: value >= 0
*/
class Program { static void Main() { int value = 4; bool b = value >= default; } }
