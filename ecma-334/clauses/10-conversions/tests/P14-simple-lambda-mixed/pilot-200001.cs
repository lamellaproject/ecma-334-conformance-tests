/*
Rules: P14-simple-lambda-mixed
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: reject
Mutate: Reader r=(ref int x,ref y)=>x+y;
Into: Reader r=default(Reader);
*/
using System;

delegate int Reader(ref int x,ref int y);
class Program
{
    static void Main()
    {
        Reader r=(ref int x,ref y)=>x+y;
    }
}
