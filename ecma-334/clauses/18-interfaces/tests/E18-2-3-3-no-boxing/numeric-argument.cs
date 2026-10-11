/*
Rules: E18-2-3-3-no-boxing
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: reject
Mutate: IRead<long> destination = source
Into: IRead<int> destination = source
Csc: CS0266
*/
interface IRead<out T> { T Read(); }
class Reader : IRead<int> { public int Read() { return 43; } }
class Program
{
    static void Main() { IRead<int> source = new Reader(); IRead<long> destination = source; }
}
