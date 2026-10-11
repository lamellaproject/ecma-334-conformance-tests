/*
Rules: E10-3-5-delegate-covariant
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: Func<long> target=(Func<long>)source;
Into: Func<long> target=default(Func<long>);
Csc: CS0030
*/
using System;


class Program
{
    static void Main()
    {
        Func<int> source=null; Func<long> target=(Func<long>)source;
    }
}
