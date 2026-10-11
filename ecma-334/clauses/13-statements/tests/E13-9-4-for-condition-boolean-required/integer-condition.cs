/*
Rules: E13-9-4-for-condition-boolean-required
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: reject
Mutate: for (; 1; )
Into: for (; true; )
*/
class Program { static void Main() { for (; 1; ) { break; } } }
