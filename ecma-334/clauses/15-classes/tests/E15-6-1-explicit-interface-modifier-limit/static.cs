/*
Rules: E15-6-1-explicit-interface-modifier-limit
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: static int IReader.Read()
Into: int IReader.Read()
Csc: CS0535; CS0539; CS8703
*/
interface IReader { int Read(); }
class Holder : IReader { static int IReader.Read() { return 47; } }
class Program { static void Main() { } }
