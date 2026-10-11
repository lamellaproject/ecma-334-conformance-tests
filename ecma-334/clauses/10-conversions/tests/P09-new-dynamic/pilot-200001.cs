/*
Rules: P09-new-dynamic
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: dynamic x=new();
Into: dynamic x=default(dynamic);
*/
using System;


class Program
{
    static void Main()
    {
        dynamic x=new();
    }
}
