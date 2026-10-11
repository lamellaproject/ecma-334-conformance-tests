/*
Rules: E10-3-6-element
Authority: ECMA-334 7th ed 10.3.6
Version: 7.3
Expected: reject
Mutate: ((int,DateTime))(1,2)
Into: ((int,DateTime))(1,default(DateTime))
*/
using System;


class Program
{
    static void Main()
    {
        var result=((int,DateTime))(1,2);
    }
}
