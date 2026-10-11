/*
Rules: E10-3-5-delegate-invariant
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: Flat<object> target=(Flat<object>)source;
Into: Flat<object> target=default(Flat<object>);
Csc: CS0030
*/
using System;

delegate T Flat<T>(T x);
class Program
{
    static void Main()
    {
        Flat<string> source=null; Flat<object> target=(Flat<object>)source;
    }
}
