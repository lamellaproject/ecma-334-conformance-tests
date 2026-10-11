/*
Rules: E15-6-1-async-return-form
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public async int Read()
Into: public int Read()
Csc: CS1983
*/
class Holder { public async int Read() { return 37; } }
class Program { static void Main() { } }
