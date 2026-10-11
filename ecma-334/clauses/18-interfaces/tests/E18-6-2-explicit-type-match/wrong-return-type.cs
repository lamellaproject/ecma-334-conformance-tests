/*
Rules: E18-6-2-explicit-type-match
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: long IRead.Read()
Into: int IRead.Read()
Csc: CS9334
*/
interface IRead { int Read(); }
class Reader : IRead
{
    public int Read() { return 227; }
    long IRead.Read() { return 229; }
}
class Program { static void Main() { } }
