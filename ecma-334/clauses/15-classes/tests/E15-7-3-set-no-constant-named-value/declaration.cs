/*
Rules: E15-7-3-set-no-constant-named-value
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: const int value = 7;
Into: const int other = 7;
*/
class Box { public int Item { set { const int value = 7; } } }
class Program { static void Main() { } }
