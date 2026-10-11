/*
Rules: E15-7-3-set-return-no-expression; E15-7-3-set-void-body-rules
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: return 4;
Into: return;
*/
class Box { public int Item { set { return 4; } } }
class Program { static void Main() { } }
