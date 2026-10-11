/*
Rules: E15-6-1-private-abstract-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: private abstract int Read();
Into: protected abstract int Read();
Csc: CS0621
*/
abstract class Holder { private abstract int Read(); }
class Program { static void Main() { } }
