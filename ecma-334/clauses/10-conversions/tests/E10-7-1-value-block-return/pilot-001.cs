/*
Rules: E10-7-1-value-block-return
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: ()=>{return;}
Into: ()=>{return 0;}
Csc: CS0126
*/
using System;


class Program
{
    static void Main()
    {
        Func<int> result=()=>{return;};
    }
}
