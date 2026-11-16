/*
Rules: E6-5-2-grammar-pp-conditional-symbol-1
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: reject
Mutate: #define @CHOSEN
Into: #define CHOSEN
*/
#define @CHOSEN
class Program
{
    static void Main() { }
}
