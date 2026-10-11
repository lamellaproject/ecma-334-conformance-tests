/*
Rules: E15-7-3-set-no-local-named-value
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: int value = 3;
Into: int other = 3;
*/
class Box { public int Item { set { int value = 3; } } }
class Program { static void Main() { } }
