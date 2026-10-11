/*
Rules: E16-2-3-no-nonref-struct-field
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: struct Container
Into: ref struct Container
*/
ref struct Entry { }
struct Container { public Entry Item; }
class Program { static void Main() { } }
