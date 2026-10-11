/*
Rules: E15-7-3-abstract-nonref-accessor-semicolon
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: reject
Mutate: get { return 9; }
Into: get;
*/
abstract class Box { public abstract int Item { get { return 9; } set; } }
class Program { static void Main() { } }
