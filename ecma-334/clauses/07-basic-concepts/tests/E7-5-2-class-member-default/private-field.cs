/*
Rules: E7-5-2-class-member-default; E7-5-3-private-domain
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: int hidden = 73;
Into: public int hidden = 73;
*/
class Item { int hidden = 73; }
class Program { static void Main() { int value = new Item().hidden; } }
