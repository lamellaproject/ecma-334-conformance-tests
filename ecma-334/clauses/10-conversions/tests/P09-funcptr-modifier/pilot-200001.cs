/*
Rules: P09-funcptr-modifier
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate*<in int,int> q
Into: delegate*<ref int,int> q
*/
using System;

static class Address{public static int Apply(ref int x)=>x;}
class Program
{
    static void Main()
    {
        unsafe {delegate*<ref int,int> p=&Address.Apply;delegate*<in int,int> q=p;}
    }
}
