/*
Rules: E10-3-5-delegate-contravariant
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: reject
Mutate: Action<object> target=(Action<object>)source;
Into: Action<object> target=default(Action<object>);
Csc: CS0030
*/
using System;


class Program
{
    static void Main()
    {
        Action<int> source=null; Action<object> target=(Action<object>)source;
    }
}
