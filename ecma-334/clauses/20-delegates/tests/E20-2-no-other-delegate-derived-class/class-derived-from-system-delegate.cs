/*
Rules: E20-2-no-other-delegate-derived-class; E20-2-declaration-only
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: class Pretender : System.Delegate
Into: class Pretender
Csc: CS0644
*/
class Pretender : System.Delegate { }
class Program { static void Main() { } }
