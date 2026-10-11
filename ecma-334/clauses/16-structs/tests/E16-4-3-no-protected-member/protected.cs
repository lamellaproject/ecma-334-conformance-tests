/*
Rules: E16-4-3-no-protected-member
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: protected int Value;
Into: private int Value;
*/
struct Entry { protected int Value; }
class Program { static void Main() { } }
