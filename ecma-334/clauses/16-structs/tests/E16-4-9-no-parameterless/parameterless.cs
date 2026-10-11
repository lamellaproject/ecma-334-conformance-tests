/*
Rules: E16-4-9-no-parameterless
Authority: ECMA-334 7th ed 16.4.9
Version: 7.3
Expected: reject
Mutate: public Entry()
Into: public Entry(int unused)
*/
struct Entry { public Entry() { } }
class Program { static void Main() { } }
