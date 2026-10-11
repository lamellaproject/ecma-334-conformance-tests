/*
Rules: E15-6-1-ordinary-method-body
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public int Read();
Into: public int Read() { return 7; }
Csc: CS0501
*/
class Holder { public int Read(); }
class Program { static void Main() { } }
