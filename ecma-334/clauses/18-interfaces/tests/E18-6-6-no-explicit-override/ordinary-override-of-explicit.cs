/*
Rules: E18-6-6-no-explicit-override
Authority: ECMA-334 7th ed 18.6.6
Version: 7.3
Expected: reject
Mutate: public override int Read()
Into: public int Read()
Csc: CS0115
*/
interface IRead { int Read(); }
class Root : IRead { int IRead.Read() { return 401; } }
class Branch : Root { public override int Read() { return 409; } }
class Program { static void Main() { } }
