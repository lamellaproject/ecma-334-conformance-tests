/*
Rules: P08-using-resource-type
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: class Lease
Into: class Lease : IDisposable
*/
using System;

// using.md L106: an ordinary reference class needs the IDisposable conversion.
class Lease
{
    public void Dispose() { }
}
class Program
{
    static void Main()
    {
        using Lease resource = new Lease();
    }
}
