/*
Rules: E12-9-8-1-no-unsafe
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: reject
Mutate: static unsafe async void Worker()
Into: static async void Worker()
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
class Program { static unsafe async void Worker() { await new Carrier(); } static void Main() { } }
