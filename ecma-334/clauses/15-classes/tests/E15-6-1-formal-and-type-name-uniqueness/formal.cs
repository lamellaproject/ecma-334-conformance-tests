/*
Rules: E15-6-1-formal-and-type-name-uniqueness
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public void Touch(int value, int value)
Into: public void Touch(int value, int other)
Csc: CS0100
*/
class Holder { public void Touch(int value, int value) { } }
class Program { static void Main() { } }
