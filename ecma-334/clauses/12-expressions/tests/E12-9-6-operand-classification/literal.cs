/*
Rules: E12-9-6-operand-classification
Authority: ECMA-334 7th ed 12.9.6
Version: 7.3
Expected: reject
Mutate: ++3
Into: ++value
*/
class Program { static void Main() { int value = 3; var result = ++3; } }
