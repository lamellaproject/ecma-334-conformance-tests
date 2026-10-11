/*
Rules: E10-5-5-operator-ambiguous
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: reject
Mutate: Second result=(Second)source;
Into: Second result=default(Second);
Csc: CS0457
*/
using System;


struct First {public static explicit operator Second(First x){return new Second();}}
struct Second {public static explicit operator Second(First x){return new Second();}}

class Program
{
    static void Main()
    {
        First source=new First(); Second result=(Second)source;
    }
}
