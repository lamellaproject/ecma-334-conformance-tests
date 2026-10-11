/*
Rules: E15-6-2-1-nested-local-name-collision
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: int T = 31;
Into: int local = 31;
Csc: CS0412
*/
class Holder { public void Touch<T>() { int T = 31; } }
class Program { static void Main() { } }
