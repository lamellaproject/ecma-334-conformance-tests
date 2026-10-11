/*
Rules: P09-conditional-invalid
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: flag ? "larch" : 17
Into: flag ? (byte)13 : (byte)17
*/
using System;


class Program
{
    static void Main()
    {
        bool flag=false; byte result=flag ? "larch" : 17;
    }
}
