/*
Rules: E15-6-1-valid-method-access-modifiers
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public private int Read()
Into: public int Read()
Csc: CS0107
*/
class Holder { public private int Read() { return 3; } }
class Program { static void Main() { new Holder().Read(); } }
