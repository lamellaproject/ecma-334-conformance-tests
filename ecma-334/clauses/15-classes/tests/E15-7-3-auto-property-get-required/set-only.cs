/*
Rules: E15-7-3-auto-property-get-required
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: int Item { set; }
Into: int Item { get; set; }
*/
class Box { public int Item { set; } }
class Program { static void Main() { } }
