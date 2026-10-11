/*
Rules: P09-funcptr-count
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate*<int,int,int> q
Into: delegate*<int,int> q
*/
using System;

static class Address{public static int Apply(int x)=>x;}
class Program
{
    static void Main()
    {
        unsafe {delegate*<int,int> p=&Address.Apply;delegate*<int,int,int> q=p;}
    }
}
