/*
Rules: E18-6-8-no-abstract-explicit
Authority: ECMA-334 7th ed 18.6.8
Version: 7.3
Expected: reject
Mutate: abstract int IRead.Read();
Into: int IRead.Read() { return 479; }
Csc: CS0106
*/
interface IRead { int Read(); }
abstract class Root : IRead { abstract int IRead.Read(); }
class Program { static void Main() { } }
