/*
Rules: P09-new-no-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: int x=1+new();
Into: int x=default(int);
*/
using System;


class Program
{
    static void Main()
    {
        int x=1+new();
    }
}
