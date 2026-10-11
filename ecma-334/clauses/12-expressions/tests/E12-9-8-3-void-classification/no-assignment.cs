/*
Rules: E12-9-8-3-void-classification
Authority: ECMA-334 7th ed 12.9.8.3
Version: 7.3
Expected: reject
Mutate: int value = await new Carrier()
Into: await new Carrier()
*/
using System;
using System.Runtime.CompilerServices;
struct Carrier { public Waiter GetAwaiter() { return new Waiter(); } }
struct Waiter : INotifyCompletion
{
    public bool IsCompleted { get { return true; } }
    public void OnCompleted(Action continuation) { }
    public void GetResult() { }
}
class Program { static async void Worker() { int value = await new Carrier(); } static void Main() { } }
