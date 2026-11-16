/*
Rules: P13-priority-conversion-operator
Authority: csc 5.12.0-1.26529.118 (C# 13.0)
Version: 13.0
Expected: reject
Mutate: [System.Runtime.CompilerServices.OverloadResolutionPriority(2)]
Into: 
*/
using System;

struct PriorityValue{[System.Runtime.CompilerServices.OverloadResolutionPriority(2)]public static implicit operator PriorityValue(int n)=>default;}
class Program
{
    static void Main()
    {
        PriorityValue value=839;
    }
}
