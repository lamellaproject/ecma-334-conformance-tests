/*
Rules: E15-6-1-ordinary-method-identifier
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: int Holder.Read()
Into: int Read()
Csc: CS0538
*/
class Holder { int Holder.Read() { return 41; } }
class Program { static void Main() { } }
