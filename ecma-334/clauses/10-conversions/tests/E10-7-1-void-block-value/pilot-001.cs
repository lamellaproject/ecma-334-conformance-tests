/*
Rules: E10-7-1-void-block-value
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: ()=>{return 61;}
Into: ()=>{return;}
Csc: CS8030
*/
using System;


class Program
{
    static void Main()
    {
        Action result=()=>{return 61;};
    }
}
