/*
Rules: E18-6-2-explicit-modifiers
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: public int IRead.Read()
Into: int IRead.Read()
Csc: CS0106
*/
interface IRead { int Read(); }
class Reader : IRead { public int IRead.Read() { return 193; } }
class Program { static void Main() { } }
