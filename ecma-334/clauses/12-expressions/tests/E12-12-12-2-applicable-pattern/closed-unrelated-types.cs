/*
Rules: E12-12-12-2-applicable-pattern
Authority: ECMA-334 7th ed 12.12.12.2
Version: 7.3
Expected: reject
Mutate: value is string text
Into: value is int text
*/
class Program { static void Main() { int value = 3; bool b = value is string text; } }
