/*
Rules: E15-6-1-extern-semicolon-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public extern int Read() => 5;
Into: public extern int Read();
Csc: CS0179
*/
class Holder { public extern int Read() => 5; }
class Program { static void Main() { } }
