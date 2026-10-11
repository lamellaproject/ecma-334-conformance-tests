/*
Rules: E7-5-2-namespace-modifier-forbidden
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: public namespace Grove
Into: namespace Grove
*/
public namespace Grove { class Item { } }
class Program { static void Main() { } }
