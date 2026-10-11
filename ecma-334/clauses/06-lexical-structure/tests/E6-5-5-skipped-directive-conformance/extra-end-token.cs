/*
Rules: E6-5-5-skipped-directive-conformance
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: reject
Mutate: #endif extra
Into: #endif
*/
#if false
#if true
#endif extra
#endif
class Program { static void Main() { } }
