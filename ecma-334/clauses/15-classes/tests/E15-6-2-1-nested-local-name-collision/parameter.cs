/*
Rules: E15-6-2-1-nested-local-name-collision
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: { int count = 29; }
Into: { int local = 29; }
Csc: CS0136
*/
class Holder { public void Touch(int count) { { int count = 29; } } }
class Program { static void Main() { } }
