/*
Rules: E12-9-3-ulong-error
Authority: ECMA-334 7th ed 12.9.3
Version: 7.3
Expected: reject
Mutate: -value
Into: +value
*/
class Program { static void Main() { ulong value = 3; var result = -value; } }
