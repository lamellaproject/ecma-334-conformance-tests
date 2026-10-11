/*
Rules: E12-8-15-operand-category
Authority: ECMA-334 7th ed 12.8.15
Version: 7.3
Expected: reject
Mutate: (3)++
Into: value++
*/
class Program { static void Main() { int value = 3; int before = (3)++; } }
