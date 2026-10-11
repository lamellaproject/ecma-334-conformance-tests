/*
Rules: E18-6-2-explicit-base-member
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: class Reader { int IRead.Read()
Into: class Reader : IRead { int IRead.Read()
Csc: CS0540
*/
interface IRead { int Read(); }
class Reader { int IRead.Read() { return 199; } }
class Program { static void Main() { } }
