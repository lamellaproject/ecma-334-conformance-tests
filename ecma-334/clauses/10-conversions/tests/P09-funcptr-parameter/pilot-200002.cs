/*
Rules: P09-funcptr-parameter; P09-funcptr-return
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate*<object,string> target=source;
Into: delegate*<string,object> target=source;
*/
using System;

static class Variance {public static object Label(string x)=>x;}
class Program
{
    static void Main()
    {
        unsafe {delegate*<string,object> source=&Variance.Label; delegate*<object,string> target=source;}
    }
}
