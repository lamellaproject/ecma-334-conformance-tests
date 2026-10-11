/*
Rules: E10-7-1-value-expression-invalid
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: Func<byte> result=()=>Trace.Value;
Into: Func<byte> result=default(Func<byte>);
Csc: CS0266; CS1662
*/
using System;

static class Trace {public static int Value=61;}
class Program
{
    static void Main()
    {
        Func<byte> result=()=>Trace.Value;
    }
}
