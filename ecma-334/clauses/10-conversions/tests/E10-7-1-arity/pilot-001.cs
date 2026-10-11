/*
Rules: E10-7-1-arity
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: Func<int,int> result=(int x,int y)=>x+y;
Into: Func<int,int> result=default(Func<int,int>);
Csc: CS1593
*/
using System;


class Program
{
    static void Main()
    {
        Func<int,int> result=(int x,int y)=>x+y;
    }
}
