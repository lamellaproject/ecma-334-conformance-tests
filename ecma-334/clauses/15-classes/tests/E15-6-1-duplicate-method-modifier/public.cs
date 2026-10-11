/*
Rules: E15-6-1-duplicate-method-modifier
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public public int Read()
Into: public int Read()
Csc: CS1004
*/
class Holder { public public int Read() { return 5; } }
class Program { static void Main() { new Holder().Read(); } }
