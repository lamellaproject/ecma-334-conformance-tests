/*
Rules: E6-5-5-conditional-group-order
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: reject
Mutate: #elif true
Into: // elif removed
*/
#if false
#else
#elif true
#endif
class Program { static void Main() { } }
