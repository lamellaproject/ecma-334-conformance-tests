/*
Rules: E6-5-2-symbol-not-boolean-token
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: reject
Mutate: #define true
Into: #define truth
*/
#define true
class Program { static void Main() { } }
