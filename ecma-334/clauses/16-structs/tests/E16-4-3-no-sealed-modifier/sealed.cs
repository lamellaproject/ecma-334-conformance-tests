/*
Rules: E16-4-3-no-sealed-modifier
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: sealed struct Entry
Into: struct Entry
*/
sealed struct Entry { }
class Program { static void Main() { } }
