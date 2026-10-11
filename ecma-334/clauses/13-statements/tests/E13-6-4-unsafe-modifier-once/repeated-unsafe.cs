/*
Rules: E13-6-4-unsafe-modifier-once
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: unsafe unsafe void Local()
Into: unsafe void Local()
*/
class Program { static void Main() { unsafe unsafe void Local() { } } }
