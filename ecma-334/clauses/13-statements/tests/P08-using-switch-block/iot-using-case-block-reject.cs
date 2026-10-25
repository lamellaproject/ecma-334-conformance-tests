/*
Rules: P08-using-switch-block
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: using Lease resource = new Lease(); resource.Touch();
Into: { using Lease resource = new Lease(); resource.Touch(); }
*/
using System;

// using.md L102; committee statements 13.14.2: a nested block supplies the scope.
class Lease : IDisposable
{
    public void Touch() { }
    public void Dispose() { }
}
class Program
{
    static void Main(string[] args)
    {
        switch (args.Length)
        {
            case 0:
                using Lease resource = new Lease(); resource.Touch();
                break;
            default: break;
        }
    }
}
