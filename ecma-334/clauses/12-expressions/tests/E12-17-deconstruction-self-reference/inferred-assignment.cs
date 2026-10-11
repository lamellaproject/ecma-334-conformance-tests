/*
Rules: E12-17-deconstruction-self-reference
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: reject
Mutate: number = 3
Into: 3
*/
class Program { static void Main() { var (first, number) = (1, number = 3); } }
