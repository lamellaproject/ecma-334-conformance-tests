/*
Rules: E8-3-11-tuple-name-distinctness
Authority: ECMA-334 7th ed 8.3.11
Version: 7.3
Expected: reject
Mutate: (int same, int same)
Into: (int same, int other)
*/
class Program { static void Main() { (int same, int same) tuple = (3, 9); } }
