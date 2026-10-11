/*
Rules: P12-collection-element-invalid
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: byte[] result=[257];
Into: byte[] result=default(byte[]);
*/
using System;


class Program
{
    static void Main()
    {
        byte[] result=[257];
    }
}
