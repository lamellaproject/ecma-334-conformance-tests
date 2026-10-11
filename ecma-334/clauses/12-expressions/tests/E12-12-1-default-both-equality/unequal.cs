/*
Rules: E12-12-1-default-both-equality
Authority: ECMA-334 7th ed 12.12.1
Version: 7.3
Expected: reject
Mutate: default != default
Into: default(int) != default
*/
class Program { static void Main() { bool b = default != default; } }
