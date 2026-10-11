/*
Rules: E15-6-1-abstract-semicolon-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract void Touch() { }
Into: public abstract void Touch();
Csc: CS0500
*/
abstract class Holder { public abstract void Touch() { } }
class Program { static void Main() { } }
