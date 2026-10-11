/*
Rules: E8-3-11-tuple-item-name-position
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: reject
Mutate: (int Item2, int tail)
Into: (int Item1, int tail)
*/
class Program { static void Main() { (int Item2, int tail) tuple = (3, 9); } }
