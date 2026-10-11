/*
Rules: E15-6-2-1-ref-no-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: ref int value = 5
Into: ref int value
Csc: CS1741
*/
class Holder { public void Touch(ref int value = 5) { value++; } }
class Program { static void Main() { } }
