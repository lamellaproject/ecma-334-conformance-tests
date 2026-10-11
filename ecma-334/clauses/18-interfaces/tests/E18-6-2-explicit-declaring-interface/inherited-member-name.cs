/*
Rules: E18-6-2-explicit-declaring-interface
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: int IDerived.Read()
Into: int IBase.Read()
Csc: CS0539
*/
interface IBase { int Read(); }
interface IDerived : IBase { }
class Reader : IDerived
{
    public int Read() { return 251; }
    int IDerived.Read() { return 257; }
}
class Program { static void Main() { } }
