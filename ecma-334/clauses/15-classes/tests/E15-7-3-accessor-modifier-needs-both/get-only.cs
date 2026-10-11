/*
Rules: E15-7-3-accessor-modifier-needs-both
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: private get
Into: get
*/
class Box { public int Item { private get { return 12; } } }
class Program { static void Main() { } }
