/*
Rules: E10-7-1-value-block-reachable
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: x=>{if(x>0)return x;}
Into: x=>{if(x>0)return x;return 0;}
Csc: CS1643
*/
using System;


class Program
{
    static void Main()
    {
        Func<int,int> result=x=>{if(x>0)return x;};
    }
}
