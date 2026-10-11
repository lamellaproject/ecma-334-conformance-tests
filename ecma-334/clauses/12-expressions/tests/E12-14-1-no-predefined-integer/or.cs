/*
Rules: E12-14-1-no-predefined-integer
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: reject
Mutate: x || y
Into: x | y
*/
class Program { static void Main() { int x = 1, y = 3; var result = x || y; } }
