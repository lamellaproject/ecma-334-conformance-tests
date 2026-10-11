/*
Rules: E12-12-1-default-is
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: reject
Mutate: default is int
Into: default(int) is int
*/
class Program { static void Main() { bool b = default is int; } }
