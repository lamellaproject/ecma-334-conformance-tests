/*
Rules: E15-6-7-abstract-semicolon-body
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: public abstract int Read() { return 19; }
Into: public abstract int Read();
Csc: CS0500
*/
abstract class Source { public abstract int Read() { return 19; } }
class Program { static void Main() { } }
