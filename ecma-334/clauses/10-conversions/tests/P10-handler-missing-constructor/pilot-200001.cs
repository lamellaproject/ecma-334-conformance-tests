/*
Rules: P10-handler-missing-constructor
Authority: csc 5.12.0-1.26529.118 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Broken h=$"{x}";
Into: Broken h=default(Broken);
*/
using System;

[System.Runtime.CompilerServices.InterpolatedStringHandler] struct Broken {public void AppendFormatted(int x){}}
class Program
{
    static void Main()
    {
        int x=349; Broken h=$"{x}";
    }
}
