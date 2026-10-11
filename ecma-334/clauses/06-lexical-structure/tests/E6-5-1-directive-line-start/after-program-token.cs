/*
Rules: E6-5-1-directive-line-start
Authority: ECMA-334 7th ed 6.5.1
Version: 7.3
Expected: reject
Mutate: #pragma
Into: 
*/
class Program { static void Main() { } } #pragma
