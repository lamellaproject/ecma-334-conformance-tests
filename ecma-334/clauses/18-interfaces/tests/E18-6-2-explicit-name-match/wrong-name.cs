/*
Rules: E18-6-2-explicit-name-match
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: int IRead.Other()
Into: int IRead.Read()
Csc: CS0539
*/
interface IRead { int Read(); }
class Reader : IRead
{
    public int Read() { return 211; }
    int IRead.Other() { return 223; }
}
class Program { static void Main() { } }
