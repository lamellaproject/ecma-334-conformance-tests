/*
Rules: P09-new-no-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: var x=new();
Into: object x=new();
*/
using System;


class Program
{
    static void Main()
    {
        var x=new();
    }
}
