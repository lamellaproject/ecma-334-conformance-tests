/*
Rules: P08-using-initializer
Authority: csc 5.12.0-1.26529.118 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: using Lease resource;
Into: using Lease resource = new Lease();
*/
using System;

// using.md L105: the declarator requires an initializer.
class Lease : IDisposable { public void Dispose() { } }
class Program
{
    static void Main()
    {
        using Lease resource;
    }
}
