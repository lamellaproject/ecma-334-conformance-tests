/*
Rules: E7-5-2-struct-member-default; E7-5-3-private-domain
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: int hidden;
Into: public int hidden;
*/
struct Item { int hidden; }
class Program { static void Main() { int value = new Item().hidden; } }
