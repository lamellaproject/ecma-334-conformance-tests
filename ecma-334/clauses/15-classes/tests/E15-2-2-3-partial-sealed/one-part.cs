/*
Rules: E15-2-2-3-partial-sealed
Authority: ECMA-334 7th ed 15.2.2.3
Version: 7.3
Expected: reject
Mutate: sealed partial class Root
Into: partial class Root
*/
partial class Root { }
sealed partial class Root { }
class Leaf : Root { }
class Program { static void Main() { } }
