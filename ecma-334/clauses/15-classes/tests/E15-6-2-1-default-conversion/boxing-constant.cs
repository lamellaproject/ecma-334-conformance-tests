/*
Rules: E15-6-2-1-default-conversion
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: object value = 23
Into: int value = 23
Csc: CS1763
*/
class Holder { public void Touch(object value = 23) { } }
class Program { static void Main() { } }
