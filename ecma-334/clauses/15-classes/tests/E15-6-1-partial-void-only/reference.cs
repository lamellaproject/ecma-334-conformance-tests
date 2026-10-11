/*
Rules: E15-6-1-partial-void-only
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: partial ref int Cell();
Into: partial void Cell();
*/
partial class Holder { partial ref int Cell(); }
class Program { static void Main() { } }
