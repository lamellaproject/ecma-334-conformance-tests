/*
Rules: E15-7-3-extern-nonref-accessor-semicolon
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: set { }
Into: set;
*/
class Box { public extern int Item { get; set { } } }
class Program { static void Main() { } }
