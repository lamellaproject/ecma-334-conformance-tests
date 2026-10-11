/*
Rules: E7-5-2-enum-member-modifier-forbidden
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: reject
Mutate: private Selected = 157
Into: Selected = 157
*/
enum Item { private Selected = 157 }
class Program { static void Main() { } }
