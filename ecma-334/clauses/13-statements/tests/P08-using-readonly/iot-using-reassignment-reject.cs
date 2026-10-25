/*
Rules: P08-using-readonly
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: resource = new Lease(2);
Into: resource.Touch();
*/
using System;

// using.md L83: the resource local is read-only, not the resource's members.
class Lease : IDisposable
{
    public Lease(int marker) { }
    public void Touch() { }
    public void Dispose() { }
}
class Program
{
    static void Main()
    {
        using Lease resource = new Lease(1);
        resource = new Lease(2);
    }
}
