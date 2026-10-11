/*
Rules: P09-funcptr-ref-result
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate*<ref readonly int> q
Into: delegate*<ref int> q
*/
using System;

static class Address{static int value=41;public static ref int Apply()=>ref value;}
class Program
{
    static void Main()
    {
        unsafe {delegate*<ref int> p=&Address.Apply;delegate*<ref readonly int> q=p;}
    }
}
