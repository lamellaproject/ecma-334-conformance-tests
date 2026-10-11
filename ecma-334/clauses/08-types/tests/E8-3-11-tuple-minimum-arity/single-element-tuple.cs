/*
Rules: E8-3-11-tuple-minimum-arity; E8-3-11-valuetuple-one-not-tuple
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: reject
Mutate: (int value) tuple = (4);
Into: int tuple = 4;
*/
class Program { static void Main() { (int value) tuple = (4); } }
