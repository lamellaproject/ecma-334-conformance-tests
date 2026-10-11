/*
Rules: E12-8-14-base-member-required
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: reject
Mutate: base.OnlyHere
Into: this.OnlyHere
*/
class Root { }
class Leaf : Root { public int OnlyHere = 3; public int Read() { return base.OnlyHere; } }
class Program { static void Main() { new Leaf().Read(); } }
