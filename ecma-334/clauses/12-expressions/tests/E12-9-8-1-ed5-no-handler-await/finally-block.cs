/*
Rules: E12-9-8-1-ed5-no-handler-await
Authority: ECMA-334 5th ed 12.8.8.1
Version: 5
Expected: reject
Version-Witness: version-witnesses/E12-9-8-1-ed5-no-handler-await/finally-block.cs.part
Mutate: await new Signal()
Into: new Signal().GetAwaiter().GetResult()
*/
using System;
using System.Runtime.CompilerServices;
struct Signal { public Waiter GetAwaiter() { return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action continuation) { }
    public void GetResult() { }
}
class Program
{
    static async void Worker()
    {
        try { }
        finally { await new Signal(); }
    }
    static void Main() { Worker(); }
}
