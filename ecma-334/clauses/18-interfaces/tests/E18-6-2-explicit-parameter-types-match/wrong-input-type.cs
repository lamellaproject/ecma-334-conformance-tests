/*
Rules: E18-6-2-explicit-parameter-types-match
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: int IRead.Read(long value)
Into: int IRead.Read(int value)
Csc: CS0539
*/
interface IRead { int Read(int value); }
class Reader : IRead
{
    public int Read(int value) { return value; }
    int IRead.Read(long value) { return 241; }
}
class Program { static void Main() { } }
