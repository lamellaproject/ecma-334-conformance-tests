/*
Rules: E16-2-3-no-class-field
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: ref struct Entry
Into: struct Entry
*/
ref struct Entry { }
class Container { public Entry Item; }
class Program { static void Main() { } }
