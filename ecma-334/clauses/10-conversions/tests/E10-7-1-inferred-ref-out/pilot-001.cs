/*
Rules: E10-7-1-inferred-ref-out
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: Change result=x=>{};
Into: Change result=default(Change);
Csc: CS1676
*/
using System;

delegate void Change(ref int x);
class Program
{
    static void Main()
    {
        Change result=x=>{};
    }
}
