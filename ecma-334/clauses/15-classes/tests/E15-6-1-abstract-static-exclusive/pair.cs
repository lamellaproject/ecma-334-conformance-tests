/*
Rules: E15-6-1-abstract-static-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract static int Read();
Into: public abstract int Read();
Csc: CS0112
*/
abstract class Holder { public abstract static int Read(); }
class Program { static void Main() { } }
