/*
Rules: E16-4-3-no-abstract-modifier
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: abstract struct Entry
Into: struct Entry
*/
abstract struct Entry { }
class Program { static void Main() { } }
