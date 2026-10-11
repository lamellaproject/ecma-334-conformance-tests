/*
Rules: E15-6-1-abstract-semicolon-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract int Read() => 3;
Into: public abstract int Read();
Csc: CS0500
*/
abstract class Holder { public abstract int Read() => 3; }
class Program { static void Main() { } }
