/*
Rules: E13-1-unsafe-context-only
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe { }
Into: { }
Csc: CS0227
*/
// This test's compiler options disable the unsafe-code subset with /unsafe-.
class Program { static void Main() { unsafe { } } }
