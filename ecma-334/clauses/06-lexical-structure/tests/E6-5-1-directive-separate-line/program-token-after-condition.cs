/*
Rules: E6-5-1-directive-separate-line
Authority: ECMA-334 7th ed 6.5.1
Version: 7.3
Expected: reject
Mutate: #if true ;
Into: #if true
*/
#if true ;
class Program { static void Main() { } }
#endif
