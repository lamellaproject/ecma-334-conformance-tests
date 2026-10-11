/*
Rules: E15-6-2-3-input-no-modification
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: reject
Mutate: in int value
Into: ref int value
Csc: CS8331
*/
class Holder { public void Edit(in int value) { value++; } }
class Program { static void Main() { } }
