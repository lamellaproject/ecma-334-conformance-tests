/*
Rules: E15-6-2-1-out-no-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: out int value = 7
Into: out int value
Csc: CS1741
*/
class Holder { public void Supply(out int value = 7) { value = 11; } }
class Program { static void Main() { } }
