/*
Rules: E10-4-2-no-user-chain; E10-5-3-no-chain
Authority: ECMA-334 7th ed 10.4.2
Version: 7.3
Expected: reject
Mutate: End result=61;
Into: End result=default(End);
Csc: CS0029
*/
using System;


struct Middle {public static implicit operator Middle(int x){return new Middle();}}
struct End {public static implicit operator End(Middle x){return new End();}}

class Program
{
    static void Main()
    {
        End result=61;
    }
}
