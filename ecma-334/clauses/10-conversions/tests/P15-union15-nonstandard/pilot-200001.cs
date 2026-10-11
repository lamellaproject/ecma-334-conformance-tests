/*
Rules: P15-union15-nonstandard
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: Final result=739;
Into: Final result=default(Final);
*/
using System;


    [System.Runtime.CompilerServices.Union]
    struct UnionValue{
        public object Value{get;} public static int Calls;
        public UnionValue(long value){Calls++;Value=value;}
        public UnionValue(string value){Calls++;Value=value;}
    }
struct Final{public static implicit operator Final(UnionValue value)=>default;}
class Program
{
    static void Main()
    {
        Final result=739;
    }
}
