/*
Rules: P12-collection-no-target
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: var values=[];
Into: int[] values=[];
*/
using System;


class Program
{
    static void Main()
    {
        var values=[];
    }
}
