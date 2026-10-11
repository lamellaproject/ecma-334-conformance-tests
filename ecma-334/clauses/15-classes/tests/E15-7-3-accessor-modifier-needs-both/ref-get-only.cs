/*
Rules: E15-7-3-accessor-modifier-needs-both
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: private get
Into: get
*/
class Box { int slot; public ref int Item { private get { return ref slot; } } }
class Program { static void Main() { } }
