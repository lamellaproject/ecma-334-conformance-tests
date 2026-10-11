/*
Rules: E15-7-3-ordinary-nonref-accessor-body
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: set;
Into: set { }
*/
class Box { public int Item { get { return 13; } set; } }
class Program { static void Main() { } }
