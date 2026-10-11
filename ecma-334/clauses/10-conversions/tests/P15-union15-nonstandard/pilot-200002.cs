/*
Rules: P15-union15-nonstandard
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: OuterUnion result=743;
Into: OuterUnion result=default(OuterUnion);
*/
using System;


    [System.Runtime.CompilerServices.Union]
    struct UnionValue{
        public object Value{get;} public static int Calls;
        public UnionValue(long value){Calls++;Value=value;}
        public UnionValue(string value){Calls++;Value=value;}
    }
[System.Runtime.CompilerServices.Union]struct OuterUnion{public object Value{get;}public OuterUnion(UnionValue value){Value=value;}}
class Program
{
    static void Main()
    {
        OuterUnion result=743;
    }
}
