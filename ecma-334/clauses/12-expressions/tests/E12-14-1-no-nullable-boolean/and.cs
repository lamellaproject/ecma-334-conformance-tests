/*
Rules: E12-14-1-no-nullable-boolean
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: reject
Mutate: x && y
Into: x & y
*/
class Program { static void Main() { bool? x = true, y = null; var result = x && y; } }
