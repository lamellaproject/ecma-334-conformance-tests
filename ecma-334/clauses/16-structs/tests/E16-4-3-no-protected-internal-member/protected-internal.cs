/*
Rules: E16-4-3-no-protected-internal-member
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: protected internal int Value;
Into: internal int Value;
*/
struct Entry { protected internal int Value; }
class Program { static void Main() { } }
