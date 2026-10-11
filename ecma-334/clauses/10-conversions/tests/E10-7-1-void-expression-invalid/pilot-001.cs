/*
Rules: E10-7-1-void-expression-invalid
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: Action<int> result=x=>x+1;
Into: Action<int> result=default(Action<int>);
Csc: CS0201
*/
using System;


class Program
{
    static void Main()
    {
        Action<int> result=x=>x+1;
    }
}
