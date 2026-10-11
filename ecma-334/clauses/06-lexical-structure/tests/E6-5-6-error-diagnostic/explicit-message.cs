/*
Rules: E6-5-6-error-diagnostic; E6-5-6-grammar-pp-diagnostic-1; E6-5-6-grammar-pp-message-1
Authority: ECMA-334 7th ed 6.5.6
Version: 7.3
Expected: reject
Mutate: #error compiler-witness
Into: #warning compiler-witness
*/
#error compiler-witness
class Program { static void Main() { } }
