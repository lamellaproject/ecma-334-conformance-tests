/*
Rules: P10-handler-append-mixed
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Broken h=$"a{x}";
Into: Broken h=default(Broken);
*/
using System;

[System.Runtime.CompilerServices.InterpolatedStringHandler] struct Broken {public Broken(int l,int c){}public void AppendLiteral(string x){}public bool AppendFormatted(int x)=>true;}
class Program
{
    static void Main()
    {
        int x=359; Broken h=$"a{x}";
    }
}
