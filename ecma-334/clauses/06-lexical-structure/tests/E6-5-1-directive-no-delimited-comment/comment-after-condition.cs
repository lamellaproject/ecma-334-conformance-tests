/*
Rules: E6-5-1-directive-no-delimited-comment
Authority: ECMA-334 7th ed 6.5.1
Version: 7.3
Expected: reject
Mutate: /* forbidden
Into: // forbidden
*/
#if true /* forbidden */
class Program { static void Main() { } }
#endif
