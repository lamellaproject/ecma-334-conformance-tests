/*
Rules: E15-7-3-nonref-get-return-expression; E15-7-3-nonref-get-body-rules
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: return;
Into: return 21;
*/
class Box { public int Item { get { return; } } }
class Program { static void Main() { } }
