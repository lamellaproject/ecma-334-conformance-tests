/*
Rules: E7-4-2-namespace-access-modifiers; E7-5-2-namespace-modifier-forbidden
Authority: ECMA-334 7th ed 7.4.2
Version: 7.3
Expected: reject
Mutate: internal namespace Grove
Into: namespace Grove
*/
internal namespace Grove { class Item { } }
class Program { static void Main() { } }
