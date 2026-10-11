/*
Rules: P09-funcptr-byref
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate*<ref object,int> q
Into: delegate*<ref string,int> q
*/
using System;

static class Address{public static int Apply(ref string x)=>x.Length;}
class Program
{
    static void Main()
    {
        unsafe {delegate*<ref string,int> p=&Address.Apply;delegate*<ref object,int> q=p;}
    }
}
