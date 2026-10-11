/*
Rules: E7-5-2-struct-member-protected-forbidden
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: protected int value;
Into: internal int value;
*/
struct Item { protected int value; }
class Program { static void Main() { } }
