/*
Rules: E10-7-1-omitted-out
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: delegate {return;}
Into: delegate(out int x){x=61;}
Csc: CS1688
*/
using System;

delegate void Make(out int x);
class Program
{
    static void Main()
    {
        Make result=delegate {return;};
    }
}
