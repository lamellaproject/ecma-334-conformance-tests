/*
Rules: E15-6-1-abstract-extern-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public abstract extern int Read();
Into: public abstract int Read();
Csc: CS0180
*/
abstract class Holder { public abstract extern int Read(); }
class Program { static void Main() { } }
