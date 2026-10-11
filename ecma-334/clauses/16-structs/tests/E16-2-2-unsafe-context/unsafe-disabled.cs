/*
Rules: E16-2-2-unsafe-context
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: unsafe struct Entry
Into: struct Entry
*/
unsafe struct Entry { }
class Program { static void Main() { } }
