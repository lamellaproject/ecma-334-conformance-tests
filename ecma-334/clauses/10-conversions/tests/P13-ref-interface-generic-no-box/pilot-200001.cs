/*
Rules: P13-ref-interface-generic-no-box
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: reject
Mutate:  where T:allows ref struct
Into: 
*/
using System;

static class Reader{public static object Box<T>(T value) where T:allows ref struct =>value;}
class Program
{
    static void Main()
    {

    }
}
