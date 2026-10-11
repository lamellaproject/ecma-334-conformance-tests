/*
Rules: E7-5-2-struct-member-protected-forbidden
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: private protected int value;
Into: private int value;
*/
struct Item { private protected int value; }
class Program { static void Main() { } }
