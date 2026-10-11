/*
Rules: E18-6-2-explicit-arity-match
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: int IRead.Read<T, U>()
Into: int IRead.Read<T>()
Csc: CS0539
*/
interface IRead { int Read<T>(); }
class Reader : IRead
{
    public int Read<T>() { return 233; }
    int IRead.Read<T, U>() { return 239; }
}
class Program { static void Main() { } }
