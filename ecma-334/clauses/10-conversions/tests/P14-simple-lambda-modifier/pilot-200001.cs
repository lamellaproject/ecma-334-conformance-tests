/*
Rules: P14-simple-lambda-modifier
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: reject
Mutate: (out x)=>{x=1;return 1;}
Into: (ref x)=>{x=1;return 1;}
*/
using System;

delegate int Reader(ref int x);
class Program
{
    static void Main()
    {
        Reader r=(out x)=>{x=1;return 1;};
    }
}
