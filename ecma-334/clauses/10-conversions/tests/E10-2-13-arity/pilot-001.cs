/*
Rules: E10-2-13-arity
Authority: ECMA-334 7th ed 10.2.13
Version: 7.3
Expected: reject
Mutate: result=(1,2);
Into: result=(1,2,3);
*/
using System;


class Program
{
    static void Main()
    {
        (int a,int b,int c) result=(1,2);
    }
}
