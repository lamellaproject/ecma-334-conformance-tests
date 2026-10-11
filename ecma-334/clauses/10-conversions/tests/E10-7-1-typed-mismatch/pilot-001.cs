/*
Rules: E10-7-1-typed-mismatch
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: Action<int> result=(long x)=>{};
Into: Action<int> result=default(Action<int>);
Csc: CS1661; CS1678
*/
using System;


class Program
{
    static void Main()
    {
        Action<int> result=(long x)=>{};
    }
}
