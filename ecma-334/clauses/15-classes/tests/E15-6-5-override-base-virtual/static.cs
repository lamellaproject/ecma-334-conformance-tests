/*
Rules: E15-6-5-override-base-virtual
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: public static int Read()
Into: public virtual int Read()
Csc: CS0506
*/
class Root { public static int Read() { return 113; } }
class Leaf : Root { public override int Read() { return 127; } }
class Program { static void Main() { } }
