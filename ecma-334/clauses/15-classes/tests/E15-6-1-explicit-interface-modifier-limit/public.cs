/*
Rules: E15-6-1-explicit-interface-modifier-limit
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public int IReader.Read()
Into: int IReader.Read()
Csc: CS0106
*/
interface IReader { int Read(); }
class Holder : IReader { public int IReader.Read() { return 43; } }
class Program { static void Main() { } }
