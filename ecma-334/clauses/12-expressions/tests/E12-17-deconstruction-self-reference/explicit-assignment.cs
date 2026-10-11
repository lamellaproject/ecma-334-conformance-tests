/*
Rules: E12-17-deconstruction-self-reference
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/explicit-assignment-0c5a9e41cb.cs.part
Mutate: number = 3
Into: 3
*/
class Program { static void Main() { (int first, int number) = (1, number = 3); } }
