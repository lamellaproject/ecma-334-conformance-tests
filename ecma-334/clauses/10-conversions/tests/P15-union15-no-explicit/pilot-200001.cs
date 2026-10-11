/*
Rules: P15-union15-no-explicit
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: UnionValue result=(UnionValue)source;
Into: UnionValue result=default(UnionValue);
*/
using System;


[System.Runtime.CompilerServices.Union]
struct UnionValue{
    public object Value{get;} public static int Calls;
    public UnionValue(long value){Calls++;Value=value;}
    public UnionValue(string value){Calls++;Value=value;}
}

class Program
{
    static void Main()
    {
        double source=751.0;UnionValue result=(UnionValue)source;
    }
}
