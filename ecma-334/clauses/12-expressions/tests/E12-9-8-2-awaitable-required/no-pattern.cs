/*
Rules: E12-9-8-2-awaitable-required
Authority: ECMA-334 7th ed 12.9.8.2
Version: 7.3
Expected: reject
Mutate: await 3
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
class Program { static async void Worker() { await 3; } static void Main() { } }
