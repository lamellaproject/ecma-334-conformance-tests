/*
Rules: E18-2-3-3-no-boxing
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: reject
Mutate: IEnumerable<long> target=source;
Into: IEnumerable<long> target=default(IEnumerable<long>);
Csc: CS0266
*/
using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        IEnumerable<int> source=new int[1]; IEnumerable<long> target=source;
    }
}
