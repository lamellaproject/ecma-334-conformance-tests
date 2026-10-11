/*
Rules: E15-6-1-extern-semicolon-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public extern void Touch() { }
Into: public extern void Touch();
Csc: CS0179
*/
class Holder { public extern void Touch() { } }
class Program { static void Main() { } }
