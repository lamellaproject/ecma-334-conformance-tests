/*
Rules: E12-9-8-1-async-body-only
Authority: ECMA-334 7th ed 12.9.8.1
Version: 7.3
Expected: reject
Mutate: static void Worker()
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
class Program { static void Worker() { await new Carrier(); } static void Main() { } }
