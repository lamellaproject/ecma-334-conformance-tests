/*
Rules: E15-6-2-1-parameter-space-unique-names
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: int count, bool count
Into: int count, bool enabled
Csc: CS0100
*/
class Holder { public void Touch(int count, bool count) { } }
class Program { static void Main() { } }
