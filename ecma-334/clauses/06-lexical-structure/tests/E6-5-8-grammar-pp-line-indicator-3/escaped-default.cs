/*
Rules: E6-5-8-grammar-pp-line-indicator-3
Authority: ECMA-334 7th ed 6.5.8
Version: 7.3
Expected: reject
Mutate: #line def\u0061ult
Into: #line default
*/
#line def\u0061ult
class Program
{
    static void Main() { }
}
