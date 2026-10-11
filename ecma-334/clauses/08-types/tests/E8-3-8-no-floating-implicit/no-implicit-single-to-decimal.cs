/*
Rules: E8-3-8-no-floating-implicit
Authority: ECMA-334 7th ed 8.3.8
Version: 7.3
Expected: reject
Mutate: decimal value = source;
Into: decimal value = (decimal)source;
*/
class Program { static void Main() { float source = 2.5f; decimal value = source; } }
