/*
Rules: P15-union15-ambiguous
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: reject
Mutate: Ambiguous result=null;
Into: Ambiguous result=default(Ambiguous);
*/
using System;

[System.Runtime.CompilerServices.Union]struct Ambiguous{public object Value{get;}public Ambiguous(Uri x){Value=x;}public Ambiguous(Version x){Value=x;}}
class Program
{
    static void Main()
    {
        Ambiguous result=null;
    }
}
