/*
Rules: E10-7-1-value-block-return
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: ()=>{return "seed";}
Into: ()=>{return 61;}
Csc: CS0029; CS1662
*/
using System;


class Program
{
    static void Main()
    {
        Func<int> result=()=>{return "seed";};
    }
}
