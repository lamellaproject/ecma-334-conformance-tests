/*
Rules: P12-collection-no-target
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
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
