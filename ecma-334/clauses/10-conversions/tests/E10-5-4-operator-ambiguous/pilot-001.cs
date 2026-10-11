/*
Rules: E10-5-4-operator-ambiguous
Authority: ECMA-334 7th ed 10.5.4
Version: 7.3
Expected: reject
Mutate: Second result=source;
Into: Second result=default(Second);
Csc: CS0457
*/
using System;


struct First {public static implicit operator Second(First x){return new Second();}}
struct Second {public static implicit operator Second(First x){return new Second();}}

class Program
{
    static void Main()
    {
        First source=new First(); Second result=source;
    }
}
