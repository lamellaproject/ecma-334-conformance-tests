/*
Rules: P09-funcptr-static
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: &value.Apply
Into: &Address.Static
*/
using System;

class Address{public int Apply(int x)=>x; public static int Static(int x)=>x;}
class Program
{
    static void Main()
    {
        unsafe {Address value=new Address(); delegate*<int,int> p=&value.Apply;}
    }
}
