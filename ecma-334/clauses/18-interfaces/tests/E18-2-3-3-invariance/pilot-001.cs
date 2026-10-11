/*
Rules: E18-2-3-3-invariance
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: reject
Mutate: List<object> target=source;
Into: List<object> target=default(List<object>);
Csc: CS0029
*/
using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        List<string> source=new List<string>(); List<object> target=source;
    }
}
