/*
Rules: E10-3-6-arity
Authority: ECMA-334 7th ed 10.3.6
Version: 7.3
Expected: reject
Mutate: ((int,int,int))(1,2)
Into: ((int,int))(1,2)
*/
using System;


class Program
{
    static void Main()
    {
        var result=((int,int,int))(1,2);
    }
}
