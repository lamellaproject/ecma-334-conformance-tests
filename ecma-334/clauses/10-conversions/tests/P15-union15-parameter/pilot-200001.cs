/*
Rules: P15-union15-parameter
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: public Invalid(ref int n)
Into: public Invalid(int n)
*/
using System;

[System.Runtime.CompilerServices.Union]struct Invalid{public object Value{get;}public Invalid(ref int n){Value=n;}}
class Program
{
    static void Main()
    {
        int n=761;Invalid value=n;
    }
}
