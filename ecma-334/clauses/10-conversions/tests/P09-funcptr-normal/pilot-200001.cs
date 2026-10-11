/*
Rules: P09-funcptr-normal
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate*<int,void>
Into: delegate*<int[],void>
*/
using System;

static class Address{public static void Apply(params int[] x){}}
class Program
{
    static void Main()
    {
        unsafe {delegate*<int,void> p=&Address.Apply;}
    }
}
